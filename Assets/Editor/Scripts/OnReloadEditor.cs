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
using LanguageExt;
using static LanguageExt.Prelude;
using UnityEngine;
using UnityEditor;
using System;
#endregion

[CustomEditor(typeof(MonoBehaviour),true)]
[CanEditMultipleObjects]
public class OnReloadEditor : Editor//, IObservable<(UnityEngine.Object[], SerializedObject)>
{
    #region Variables

    #endregion

    #region Methods
    [InitializeOnLoadMethod]
    static void OnLoad()
    {
        
    }

    //public IDisposable Subscribe(IObserver<(UnityEngine.Object[], SerializedObject)> observer)
    //{
    //    observer.OnNext((targets, serializedObject));
    //}


    #endregion Methods
}
