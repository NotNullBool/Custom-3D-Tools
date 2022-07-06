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
using System.Runtime.CompilerServices;
using System.Text;
#endregion

internal interface ITupleSerializableInternal : ITuple
{
    string ToString(StringBuilder sb);
}

[Serializable]
public class SerializableTuple<T1> : Tuple<T1>
{
    [field: SerializeField] public new T1 Item1{ get; private set; }
    public SerializableTuple(T1 item1) : base(item1) => Item1 = item1;
}

[Serializable]
public class SerializableTuple<T1,T2> : IStructuralComparable, IStructuralEquatable, IComparable, ITuple, ITupleSerializableInternal
{
    [field: SerializeField] public T1 Item1 { get; private set; }
    [field: SerializeField] public T2 Item2 { get; private set; }
    int ITuple.Length => 2;

    object ITuple.this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                        return Item1;
                case 1:
                        return Item2;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    public SerializableTuple(T1 item1, T2 item2) => (Item1, Item2) = (item1, item2);

    int IStructuralComparable.CompareTo(object other, IComparer comparer)
    {
        throw new NotImplementedException();
    }
    int IComparable.CompareTo(object obj)
    {
        throw new NotImplementedException();
    }

    bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    {
        throw new NotImplementedException();
    }

    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
        throw new NotImplementedException();
    }

    string ITupleSerializableInternal.ToString(StringBuilder sb)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}