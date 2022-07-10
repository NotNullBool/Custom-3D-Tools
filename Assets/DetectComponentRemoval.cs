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
using System.Reflection;
using System.Linq;
using NullBool.Extensions;
#endregion

//[ExecuteInEditMode]
//public class DetectComponentRemoval : MonoBehaviour
//{
//    #region Variables
//    List<(MonoBehaviour Component,System.Type Type)> _ObservedComponents = new List<(MonoBehaviour Component, System.Type Type)>();
//    MonoBehaviour[] _CurrentComponents;
//    #endregion
//    #region Methods
//    void Reset()
//    {
//        //hideFlags = HideFlags.HideInInspector;
//        _CurrentComponents = GetComponents<MonoBehaviour>();
//        var components = _CurrentComponents.Where(x => x.GetType().GetCustomAttribute<OnComponentRemoveAttribute>() != null).ToArray();
//        foreach (var item in components)
//        {
//            _ObservedComponents.Add((item,item.GetType()));
//        }
        
//    }
//    private void Update()
//    {
//        foreach (var nullComponent in _ObservedComponents.Where(x => x.Component == null))
//        {
//            Debug.Log(nullComponent.Type);
//            //_ObservedComponents.Remove(nullComponent);
//        }
//        _ObservedComponents.RemoveAll(x => x.Component == null);
//    }

//    private bool TryUpdateComponentList() 
//    {
//        return TryUpdateComponentList(_CurrentComponents, out _CurrentComponents);
//    }

//    private bool TryUpdateComponentList(MonoBehaviour[] components, out MonoBehaviour[] currentComponents)
//    {
//        var newComponents = GetComponents<MonoBehaviour>();
//        if (components != newComponents)
//        {
//            currentComponents = newComponents;
//            return true;
//        }
//        currentComponents = components;
//        return false;
//    }
//    #endregion Methods
//}
