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
using UnityEngine;
using UnityEditor;
#endregion

public class Test : UnityEngine.InputSystem.PlayerInput
{
    #region Variables

    #endregion
    #region Methods
    /// <summary>
    /// <see cref="Start"/> is called before the first frame update
    /// </summary>
    void Start()
    {
        
        //Observable.EveryUpdate().Subscribe(_ => Debug.Log("Hello world update"));
    }

    //[OnComponentRemoveMethod]
    //static public void ComponentRemoved()
    //{
    //    Debug.Log("Component Removed events");
    //}
    #endregion Methods
}
