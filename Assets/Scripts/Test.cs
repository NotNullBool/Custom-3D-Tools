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

using UnityEngine;
#endregion

public class Test : MonoBehaviour
{
    #region Variables
    [SerializeField] SerializableTuple<int,string> _tuple;
    #endregion
    
    #region Methods
    /// <summary>
    /// <see cref="Start"/> is called before the first frame update
    /// </summary>
    void Start()
    {
        Debug.Log(_tuple);
    }

    /// <summary>
    /// <see cref="Update"/> is called once per frame
    /// </summary>
    void Update()
    {
        
    }
    #endregion Methods
}
