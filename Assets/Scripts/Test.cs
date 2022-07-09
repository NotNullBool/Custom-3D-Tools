#region Copyright (c)
/****************************************
 * Copyright (c) All rights reserved to
 * !NullBool, NotNullBool
 * Contact info: notnullbool@gmail.com
 ****************************************/
#endregion

#region Imports
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
#endregion

public class Test : MonoBehaviour
{
    #region Variables
    [SerializeField] SerializableTuple<int,string,int,int,int,int,int,SerializableTuple<int>> _Tuple;
    [SerializeField] SerializeableDictionary<string, int> _Dictionary = new SerializeableDictionary<string, int>();
    #endregion
    
    #region Methods
    /// <summary>
    /// <see cref="Start"/> is called before the first frame update
    /// </summary>
    void Start()
    {
        foreach (var kvp in _Dictionary)
        {
            Debug.Log($"{kvp.Key} {kvp.Value}");
        }
    }

    /// <summary>
    /// <see cref="Update"/> is called once per frame
    /// </summary>
    void Update()
    {
        
    }
    #endregion Methods
}
