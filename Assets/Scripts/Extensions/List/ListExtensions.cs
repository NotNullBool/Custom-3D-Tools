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

namespace NullBool.Extensions
{
    public static  partial class ListExtensions
    {
        #region Variables

        #endregion
        #region Methods        
        /// <summary>
        /// Gets the last index position.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static int GetLastIndexPostion<T>(this List<T> @this) => @this.Count - 1;
        #endregion Methods
    }
}
