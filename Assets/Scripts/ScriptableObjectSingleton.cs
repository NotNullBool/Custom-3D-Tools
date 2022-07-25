#region Copyright (c)
/****************************************
 * Copyright (c) All rights reserved to
 * !NullBool, NotNullBool
 * Contact info: notnullbool@gmail.com
 ****************************************/ 
#endregion

#region Imports
using static NullBool.ConstLib;
using static LanguageExt.Prelude;
using UnityEngine;
using static NullBool.Extensions.ScriptableObjectExtensions;
using Unity.VisualScripting;
#endregion


public abstract class ScriptableObjectSingleton : ScriptableObject
{
    #region Variables    
    private const string DEFAULT_PATH_INSIDE_RESOURCE_FOLDER = "ScriptableObjects";

    private static string _PathInsideResourceFolder = null;
    protected static string p_PathInsideResourceFolder { get => _PathInsideResourceFolder ?? DEFAULT_PATH_INSIDE_RESOURCE_FOLDER;
                                                         set => _PathInsideResourceFolder ??= value; }

    private const string DEFAULT_RESOURCE_FOLDER_PATH = "Assets";

    private static string _ResourceFolderPath = null;
    protected static string p_ResourceFolderPath { get => _ResourceFolderPath ?? DEFAULT_RESOURCE_FOLDER_PATH;
                                                   set => _ResourceFolderPath ??= value; }
    internal string ResourceFolderPath => p_ResourceFolderPath;

    protected static bool p_UseEditorDefaultResourcesFolder = false;

    private static ScriptableObjectSingleton _Instance;
    internal ScriptableObjectSingleton Instance { get => _Instance; set => _Instance = value; }
    public static T GetInstance<T>() where T : ScriptableObjectSingleton
    {
        _Instance = Optional(_Instance).IfNone(() =>
        {
            var assetLocation = $"{p_PathInsideResourceFolder}/{typeof(T).ToString()}";

            var assetPath = p_UseEditorDefaultResourcesFolder ? $"{ASSETS}/{EDITOR_DEFAULT_RESOURCES}/{p_PathInsideResourceFolder}" :
                                                                 $"{p_ResourceFolderPath}/{RESOURCES}/{p_PathInsideResourceFolder}";
            var assetName = typeof(T).ToString();



            var instance = Optional(LoadAsset<T>(assetLocation, p_UseEditorDefaultResourcesFolder)).
                       IfNone(() => CreateAsset<T>(assetPath, assetName));

            instance.InvokeOnInit();
            return instance;
        });
        return (T)_Instance;
    }

    #endregion
    #region Methods

    /// <summary>
    /// Called when first instance created.
    /// </summary>
    protected virtual void OnInit() { }
    internal void InvokeOnInit() => OnInit();
    #endregion Methods
}