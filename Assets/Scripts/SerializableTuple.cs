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
using System.Runtime.CompilerServices;
#endregion

internal interface ITupleInternal 
{
    object this[int index] { get; }
    int Length { get; }
}

[Serializable]
public struct SerializableValueTuple<T1> : ITupleInternal 
{
    #region Variables
    [SerializeField] private T1 _Item1;
    #endregion

    #region Methods

    public SerializableValueTuple(T1 item1) => _Item1 = item1;


    public ValueTuple<T1> ToValueTuple() => ValueTuple.Create(this._Item1);
    object ITupleInternal.this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: 
                    return _Item1;
                default: 
                    throw new IndexOutOfRangeException();
            }
        }
    }

    int ITupleInternal.Length => 1;

    #endregion Methods
}
[Serializable]
public struct SerializableValueTuple<T1, T2> : ITupleInternal
{
    #region Variables
    [SerializeField] private T1 _Item1;
    [SerializeField] private T2 _Item2;
    #endregion

    #region Methods

    public SerializableValueTuple(T1 item1, T2 item2) => 
        (_Item1,_Item2) = 
        (item1,item2);


    public ValueTuple<T1,T2> ToValueTuple() => ValueTuple.Create(
        this._Item1,
        this._Item2);

    object ITupleInternal.this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _Item1;
                case 1:
                    return _Item2;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    int ITupleInternal.Length => 2;

    #endregion Methods
}
[Serializable]
public struct SerializableValueTuple<T1, T2, T3> : ITupleInternal
{
    #region Variables
    [SerializeField] private T1 _Item1;
    [SerializeField] private T2 _Item2;
    [SerializeField] private T3 _Item3;
    #endregion

    #region Methods

    public SerializableValueTuple(T1 item1, T2 item2, T3 item3) => 
        (_Item1, _Item2, _Item3) =
        (item1, item2, item3);


    public ValueTuple<T1, T2, T3> ToValueTuple() => ValueTuple.Create(
        this._Item1,
        this._Item2,
        this._Item3);

    object ITupleInternal.this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _Item1;
                case 1:
                    return _Item2;
                case 2:
                    return _Item3;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    int ITupleInternal.Length => 3;

    #endregion Methods
}
[Serializable]
public struct SerializableValueTuple<T1, T2, T3, T4> : ITupleInternal
{
    #region Variables
    [SerializeField] private T1 _Item1;
    [SerializeField] private T2 _Item2;
    [SerializeField] private T3 _Item3;
    [SerializeField] private T4 _Item4;
    #endregion

    #region Methods

    public SerializableValueTuple(T1 item1, T2 item2, T3 item3, T4 item4) =>
        (_Item1, _Item2, _Item3, _Item4) =
        (item1, item2, item3, item4);


    public ValueTuple<T1, T2, T3, T4> ToValueTuple() => ValueTuple.Create(
        this._Item1,
        this._Item2,
        this._Item3,
        this._Item4);

    object ITupleInternal.this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _Item1;
                case 1:
                    return _Item2;
                case 2:
                    return _Item3;
                case 3:
                    return _Item4;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    int ITupleInternal.Length => 4;

    #endregion Methods
}
[Serializable]
public struct SerializableValueTuple<T1, T2, T3, T4, T5> : ITupleInternal
{
    #region Variables
    [SerializeField] private T1 _Item1;
    [SerializeField] private T2 _Item2;
    [SerializeField] private T3 _Item3;
    [SerializeField] private T4 _Item4;
    [SerializeField] private T5 _Item5;
    #endregion

    #region Methods

    public SerializableValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) =>
        (_Item1, _Item2, _Item3, _Item4, _Item5) =
        (item1, item2, item3, item4, item5);


    public ValueTuple<T1, T2, T3, T4, T5> ToValueTuple() => ValueTuple.Create(
        this._Item1,
        this._Item2,
        this._Item3,
        this._Item4,
        this._Item5);

    object ITupleInternal.this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _Item1;
                case 1:
                    return _Item2;
                case 2:
                    return _Item3;
                case 3:
                    return _Item4;
                case 4:
                    return _Item5;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    int ITupleInternal.Length => 5;

    #endregion Methods
}
[Serializable]
public struct SerializableValueTuple<T1, T2, T3, T4, T5, T6> : ITupleInternal
{
    #region Variables
    [SerializeField] private T1 _Item1;
    [SerializeField] private T2 _Item2;
    [SerializeField] private T3 _Item3;
    [SerializeField] private T4 _Item4;
    [SerializeField] private T5 _Item5;
    [SerializeField] private T6 _Item6;
    #endregion

    #region Methods

    public SerializableValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) =>
        (_Item1, _Item2, _Item3, _Item4, _Item5, _Item6) =
        (item1, item2, item3, item4, item5, item6);


    public ValueTuple<T1, T2, T3, T4, T5, T6> ToValueTuple() => ValueTuple.Create(
        this._Item1,
        this._Item2,
        this._Item3,
        this._Item4,
        this._Item5,
        this._Item6);

    object ITupleInternal.this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _Item1;
                case 1:
                    return _Item2;
                case 2:
                    return _Item3;
                case 3:
                    return _Item4;
                case 4:
                    return _Item5;
                case 5:
                    return _Item6;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    int ITupleInternal.Length => 6;

    #endregion Methods
}
[Serializable]
public struct SerializableValueTuple<T1, T2, T3, T4, T5, T6, T7> : ITupleInternal
{
    #region Variables
    [SerializeField] private T1 _Item1;
    [SerializeField] private T2 _Item2;
    [SerializeField] private T3 _Item3;
    [SerializeField] private T4 _Item4;
    [SerializeField] private T5 _Item5;
    [SerializeField] private T6 _Item6;
    [SerializeField] private T7 _Item7;
    #endregion

    #region Methods

    public SerializableValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) =>
        (_Item1, _Item2, _Item3, _Item4, _Item5, _Item6, _Item7) =
        (item1, item2, item3, item4, item5, item6, item7);


    public ValueTuple<T1, T2, T3, T4, T5, T6, T7> ToValueTuple() => ValueTuple.Create(
        this._Item1,
        this._Item2,
        this._Item3,
        this._Item4,
        this._Item5,
        this._Item6,
        this._Item7);

    object ITupleInternal.this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _Item1;
                case 1:
                    return _Item2;
                case 2:
                    return _Item3;
                case 3:
                    return _Item4;
                case 4:
                    return _Item5;
                case 5:
                    return _Item6;
                case 6:
                    return _Item7;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    int ITupleInternal.Length => 7;

    #endregion Methods
}
[Serializable]
public struct SerializableValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> : ITupleInternal
{
    #region Variables
    [SerializeField] private T1 _Item1;
    [SerializeField] private T2 _Item2;
    [SerializeField] private T3 _Item3;
    [SerializeField] private T4 _Item4;
    [SerializeField] private T5 _Item5;
    [SerializeField] private T6 _Item6;
    [SerializeField] private T7 _Item7;
    [SerializeField] private TRest _Rest;

    #endregion

    #region Methods

    public SerializableValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest) 
    {
        if (rest is not ITupleInternal)
        {
            throw new ArgumentException("ArgumentExeception_SerializableTupleLastArgumentNotASerializableTuple");
        }
        (_Item1, _Item2, _Item3, _Item4, _Item5, _Item6, _Item7,_Rest) =
        (item1, item2, item3, item4, item5, item6, item7,rest);

    }


    public ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> ToValueTuple()
    {
        var tupleGen= new dynamic[7];
        for (int i = 0; i < ((ITupleInternal)this).Length; i++)
        {
            if ((i%8) == 0)
            {
                foreach (var item in tupleGen)
                {

                }
            }
        }
    }
    object ITupleInternal.this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _Item1;
                case 1:
                    return _Item2;
                case 2:
                    return _Item3;
                case 3:
                    return _Item4;
                case 4:
                    return _Item5;
                case 5:
                    return _Item6;
                case 6:
                    return _Item7;
            }

            return ((ITupleInternal)_Rest)[index - 7];
        }
    }

    int ITupleInternal.Length => 7 + ((ITupleInternal)_Rest).Length;

    #endregion Methods
}