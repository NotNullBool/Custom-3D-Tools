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

public class Test : MonoBehaviour
{
    #region Variables

    [SerializeField]private string _ChangeValue;
    private void OnValidate()
    {
        _ = TestingSingleton.Instance;
    }
    #endregion
    #region Methods
    /// <summary>
    /// <see cref="Start"/> is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// <see cref="Update"/> is called once per frame
    /// </summary>
    void Update()
    {
        
    }
    #endregion Methods
}
