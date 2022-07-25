#region Copyright (c)
/****************************************
 * Copyright (c) All rights reserved to
 * !NullBool, NotNullBool
 * Contact info: notnullbool@gmail.com
 ****************************************/ 
#endregion

#region Imports
using UnityEngine;
using System;

#if UNITY_EDITOR
using UniRx;
using UnityEditor;
using System.Reflection;
using System.Linq;
using NullBool.UniEditor;
#endif

#endregion

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class OnComponentRemoveMethodAttribute : PropertyAttribute
{
    #region Variables
    #endregion
    #region Methods
    public OnComponentRemoveMethodAttribute()
    {
        
    }

    #if UNITY_EDITOR
    [InitializeOnLoadMethod]
    public static void OnComponentRemoved() => ObservableEditor.EveryOnDisable.Select(x =>
    {
        var methods = x.Target.GetType().GetMethods().Where(method =>
        {
            bool hasAttribute = method.GetCustomAttribute<OnComponentRemoveMethodAttribute>() != null;
            if (hasAttribute && !method.IsStatic)
            {
                Debug.Assert(method.IsStatic, $"Method: {method.Name} in: {method.DeclaringType} is not static.");
            }
            return hasAttribute;
        });

        object[] @params = new object[1] { x.Target };

        foreach (var method in methods)
        {
            string DefaultErrorMessage() => $"Method: {method.Name} in: {method.DeclaringType} params are not 0 or 1 and equal to {@params[0].GetType()}";

            var methodParams = method.GetParameters();

            switch (methodParams.Length)
            {
                case 0:
                    break;
                case 1:
                    if (methodParams[0].GetType() != @params[0].GetType())
                    {
                        break;
                    }
                    goto default;
                default:
                    Debug.Assert(false, DefaultErrorMessage());
                    break;
            }
        }
        return (methods: methods, @params: @params, Target: x.Target);
    }).Where(x => x.methods.Length() != 0).Subscribe(x =>
    {
        foreach (var method in x.methods)
        {

        }
    });
    #endif
    #endregion Methods
}
