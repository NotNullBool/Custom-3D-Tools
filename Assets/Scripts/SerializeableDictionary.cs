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
using System;
using System.Linq;
using NullBool.Extensions;
#endregion

[System.Serializable]
public class SerializeableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    #region Variables
    [UnityEngine.SerializeField] private List<SerializableTuple<TKey, TValue>> _KeyValuePairs = new List<SerializableTuple<TKey, TValue>>();
    private Dictionary<TKey, TValue> @this;
    private (TKey key, TValue value, int? index) _TempKeyValuePair = (default(TKey), default(TValue), null);
    #endregion

    #region Methods

    public SerializeableDictionary()
    {
        @this = this as Dictionary<TKey,TValue>;
    }

    public void OnBeforeSerialize()
    {
        _KeyValuePairs.Clear();

        //Dictionary to tuple list
        foreach (var kvp in @this)
        {
            _KeyValuePairs.Add(
                SerializableTuple.Create(kvp.Key, kvp.Value));
        }

        //Add empty value to inspector
        if (_TempKeyValuePair.index.HasValue)
        {
            _KeyValuePairs.Add(SerializableTuple.Create(_TempKeyValuePair.key, _TempKeyValuePair.value));
        }
    }

    public void OnAfterDeserialize()
    {
        @this.Clear();
        _TempKeyValuePair.index = null;

        //Tuple list to dictionary if not empty
        for (int index = 0; index < _KeyValuePairs.Count; index++)
        {
            (TKey key, TValue value) = _KeyValuePairs[index];

            if (!key.IsDefaultOrEmpty())
            {
                if (!@this.TryAdd(key, value) && _KeyValuePairs.GetLastIndexPostion() == index)
                {
                    _TempKeyValuePair.index = index;
                }
            }
            else if (_KeyValuePairs.GetLastIndexPostion() == index)
            {
                _TempKeyValuePair.index = index;
            }
        }
    }
    #endregion Methods
}
