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
#endregion

[OnComponentRemove("hi")]
public class Test : MonoBehaviour
{
    #region Variables

    #endregion
    #region Methods
    /// <summary>
    /// <see cref="Start"/> is called before the first frame update
    /// </summary>
    void Start()
    {     
        Observable.EveryUpdate().Subscribe(_ => Debug.Log("Hello world update"));
    }
    #endregion Methods
}
