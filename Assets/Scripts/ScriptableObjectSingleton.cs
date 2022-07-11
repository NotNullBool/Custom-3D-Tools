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
using UniRx;
using UniRx.Triggers;

using UnityEditor;

using UnityEngine;
#endregion

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{
    #region Variables
    private const string SCRIPTABLE_OBJECT_FOLDER = "ScriptableObjects";
    private const string ASSETS_RESOURCES_FOLDER = "Assets/Resources";
    private static T _Instance;
    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                
                 _Instance = Resources.Load<T>($"{SCRIPTABLE_OBJECT_FOLDER}/{typeof(T).ToString()}");
                if (_Instance == null)
                {
                    T asset = ScriptableObject.CreateInstance<T>();

                    if (!AssetDatabase.IsValidFolder(ASSETS_RESOURCES_FOLDER))
                    {
                        AssetDatabase.CreateFolder("Assets", "Resources");
                    }
                    if (!AssetDatabase.IsValidFolder($"{ASSETS_RESOURCES_FOLDER}/{SCRIPTABLE_OBJECT_FOLDER}"))
                    {
                        AssetDatabase.CreateFolder(ASSETS_RESOURCES_FOLDER, $"{SCRIPTABLE_OBJECT_FOLDER}");
                    }

                    AssetDatabase.CreateAsset(asset, $"{ASSETS_RESOURCES_FOLDER}/{SCRIPTABLE_OBJECT_FOLDER}/{typeof(T).ToString()}.asset");
                    AssetDatabase.SaveAssets();
                    _Instance = asset;

                }
                (_Instance as ScriptableObjectSingleton<T>).OnInit();
            }
            return _Instance;
        }
    }
    #endregion
    #region Methods
    protected virtual void OnInit() { }
    #endregion Methods
}
