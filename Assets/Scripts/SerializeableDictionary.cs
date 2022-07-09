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
using static LanguageExt.Prelude;
using UnityEngine;
using System;
#endregion

[System.Serializable]
public class SerializeableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    #region Variables
    [UnityEngine.SerializeField] private List<SerializableTuple<TKey, TValue>> _KeyValuePairs = new List<SerializableTuple<TKey, TValue>>();
    private Dictionary<TKey, TValue> @this;
    #endregion

    #region Methods

    public SerializeableDictionary()
    {
        @this = this as Dictionary<TKey,TValue>;
    }

    public void OnBeforeSerialize()
    {
        _KeyValuePairs.Clear();

        foreach (var kvp in @this)
        {
            _KeyValuePairs.Add(
                SerializableTuple.Create(kvp.Key, kvp.Value));
        }
    }

    public void OnAfterDeserialize()
    {
        @this.Clear();

        throw new NotImplementedException();

        for (int i = 0; i < _KeyValuePairs.Length(); i++)
        {
            (TKey key, TValue value) = _KeyValuePairs[i];
            if (@this.ContainsKey(key))
            {
                _KeyValuePairs[i] = SerializableTuple.Create(default(TKey), default(TValue));
            }
            else
            {
                @this.Add(key, value);
            }
        }
    }
    #endregion Methods
}
