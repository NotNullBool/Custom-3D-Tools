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
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using NullBool.Extensions;
#endregion

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class OnComponentRemoveAttribute : PropertyAttribute
{
    #region Variables
    public string StaticMethodToCall;
    public string ParameterForStaticMethod;
    #endregion
    #region Methods
    public OnComponentRemoveAttribute(string staticMethodToCall, string paramToCopyOnAddComponent = null)
    {
        throw new NotImplementedException();
        if (staticMethodToCall.IsDefaultOrEmpty())
        {
            throw new ArgumentException($"{staticMethodToCall} isnt a method");
        }
        (StaticMethodToCall, ParameterForStaticMethod) = (staticMethodToCall, paramToCopyOnAddComponent);
        
    } 

    public void Deconstruct(out string staticMethodToCall, out string parameterForStaticMethod) => (staticMethodToCall, parameterForStaticMethod) = 
                                                                                                   (StaticMethodToCall, ParameterForStaticMethod);
    #endregion Methods
}

//[CustomEditor(typeof(Test))]
//[CanEditMultipleObjects]
//public class OnComponentRemoveAttributeEditor : Editor
//{
//    Type _TargetType;
//    dynamic[] _Parameters = null;
//    MethodInfo _StaticMethod;

//    private void Reset()
//    {
//        Debug.Log("reset");
//        if (target != null)
//        {
//            _TargetType = target.GetType();
//            (string staticMethodName, string paramNameForMethod) = _TargetType.GetCustomAttribute<OnComponentRemoveAttribute>();
//            if (!paramNameForMethod.IsDefaultOrEmpty())
//            {
//                var param = _TargetType.GetField(paramNameForMethod);
//                if (param.GetType().IsArray)
//                {
//                    var array = (Array)param.GetValue(target);
//                    _Parameters = new dynamic[array.Length];
//                    for (int i = 0; i < array.Length; i++)
//                    {
//                        _Parameters[i] = array.GetValue(i);
//                    }
//                }
//                else
//                {
//                    _Parameters = new dynamic[1] { param.GetValue(target) };
//                }
//            }
//            var method = _TargetType.GetMethod(staticMethodName, BindingFlags.Static);

//            if (!method.IsStatic || method == null)
//            {
//                throw new ArgumentException($"{target.name}'s method: {staticMethodName} is not static");
//            }
//            _StaticMethod = method;
//        }
//    }
//    private void OnDisable()
//    {
//        if (target == null)
//        {
//            //call method
//            _StaticMethod.Invoke(null, _Parameters);
//        }
//    }
//}
