using System.Collections;
using System.Collections.Generic;
using LanguageExt;
using static LanguageExt.Prelude;
using UnityEngine;
using NullBool.Extensions;

public class ExeclusiveComponentManager : MonoBehaviour
{
    static private ExeclusiveComponentManager instance;
    public static ExeclusiveComponentManager Instance 
    {
        get 
        {
            return Optional(instance).IfNone(() =>
            {
                var gameObject = UnityObjectExtensions.NewUnityObjectAsHidden<GameObject>();
                return instance = gameObject.AddComponent<ExeclusiveComponentManager>();
            });
        } 
    }
}
