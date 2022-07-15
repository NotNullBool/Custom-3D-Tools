#region Copyright (c)
/****************************************
 * Copyright (c) All rights reserved to
 * !NullBool, NotNullBool
 * Contact info: notnullbool@gmail.com
 ****************************************/ 
#endregion

#region Imports
using System.Collections;
using System.Collections.Generic;
using System.Text;

using UniRx;
using UniRx.Triggers;
using UnityEditor;
using UnityEngine;
#endregion

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObjectSingleton<T>
{
    #region Variables    
    private const string DEFAULT_PATH_INSIDE_RESOURCE_FOLDER = "ScriptableObjects";

    private static string _PathInsideResourceFolder = null;
    protected static string p_PathInsideResourceFolder { get => _PathInsideResourceFolder?? DEFAULT_PATH_INSIDE_RESOURCE_FOLDER;
                                                         set => _PathInsideResourceFolder = _PathInsideResourceFolder ?? value; }

    private const string DEFAULT_RESOURCE_FOLDER_PATH = "Assets";

    private static string _ResourceFolderPath = null;
    protected static string p_ResourceFolderPath { get => _ResourceFolderPath ?? DEFAULT_RESOURCE_FOLDER_PATH;
                                                   set => _ResourceFolderPath = _ResourceFolderPath ?? value; }

    protected static bool p_UseEditorDefaultResourcesFolder = false;

    private const string RESOURCES = "Resources";
    private const string EDITOR_DEFAULT_RESOURCES = "Editor Default Resources";
    private const string ASSETS = "Assets";

    private static T _Instance;
    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                var assetLocation = $"{p_PathInsideResourceFolder}/{typeof(T).ToString()}";

                _Instance = !p_UseEditorDefaultResourcesFolder ? (T)Resources.Load(assetLocation) :
                                                                 (T)EditorGUIUtility.Load(assetLocation);
                
                if (_Instance == null)
                {
                    
                    T asset = ScriptableObject.CreateInstance<T>();

                    string assetPath = !p_UseEditorDefaultResourcesFolder ? $"{p_ResourceFolderPath}/{RESOURCES}/{p_PathInsideResourceFolder}" :
                                                                            $"{ASSETS}/{EDITOR_DEFAULT_RESOURCES}/{p_PathInsideResourceFolder}";
                    string[] folders = assetPath.Split("/");
                    for (int i = 0; i < folders.Length; i++)
                    {
                        int previousFolderIndex = i > 0 ? i - 1 : 0;

                        string iterFolderPath = string.Join('/', folders[0..(previousFolderIndex)]);

                        if (!AssetDatabase.IsValidFolder($"{iterFolderPath}/{folders[i]}")) 
                            AssetDatabase.CreateFolder(iterFolderPath, folders[i]);
                    }

                    AssetDatabase.CreateAsset(asset, $"{assetPath}/{typeof(T).ToString()}.asset");
                    AssetDatabase.SaveAssets();

                    _Instance = asset;

                }
                _Instance.OnInit();
            }
            return _Instance;
        }
    }
    #endregion
    #region Methods
    protected virtual void OnInit() { }
    #endregion Methods
}
