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
using System.Diagnostics;

using UniRx;
using UniRx.Triggers;
using UnityEngine;
#endregion

namespace NullBool.Extensions
{
    public static partial class ObjectExtensions
    {
        #region Variables

        #endregion
        #region Methods
        public static bool IsDefaultOrEmpty<T>(this T @this) => (@this == null || @this.Equals(default(T)) || string.IsNullOrEmpty(@this as string));
        
        public static T StaticCast<T>(this T @this) => @this;
        #endregion Methods
    }
}
