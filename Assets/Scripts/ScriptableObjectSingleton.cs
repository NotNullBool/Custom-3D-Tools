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
using static NullBool.ConstLib;
using LanguageExt;
using static LanguageExt.Prelude;
using UnityEditor;
using UnityEngine;
using static NullBool.Extensions.ScriptableObjectExtensions;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
#endregion

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObjectSingleton<T>
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

    protected static bool p_UseEditorDefaultResourcesFolder = false;

    private static T _Instance;
    public static T Instance
    {
        get
        {

            return _Instance = Optional(_Instance).IfNone(() => 
            {
                var assetLocation = $"{p_PathInsideResourceFolder}/{typeof(T).ToString()}";

                var assetPath = p_UseEditorDefaultResourcesFolder ? $"{p_ResourceFolderPath}/{RESOURCES}/{p_PathInsideResourceFolder}" :
                                                                    $"{ASSETS}/{EDITOR_DEFAULT_RESOURCES}/{p_PathInsideResourceFolder}";
                var assetName = typeof(T).ToString();



                var instance = Optional(LoadAsset<T>(assetLocation, p_UseEditorDefaultResourcesFolder)).
                               IfNone(() => CreateAsset<T>(assetPath, assetName));

                instance.OnInit();

                return instance;
            });
        }
    }


    #endregion
    #region Methods

    /// <summary>
    /// Called when first instance created.
    /// </summary>
    protected virtual void OnInit() { }
    #endregion Methods
}
