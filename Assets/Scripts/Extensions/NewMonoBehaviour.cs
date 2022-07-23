using System.Collections;
using UnityEngine;

namespace NullBool.Extensions
{
    public static class UnityObjectExtensions
    {
        public static T NewUnityObjectAsHidden<T>(HideFlags flags = HideFlags.HideInHierarchy | HideFlags.HideInInspector) where T : Object, new()
        {
            var output = default(T); 
            output.hideFlags = flags;
            return output;
        }
    }
}