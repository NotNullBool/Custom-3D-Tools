using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
 
/// <summary>
/// Helper so we can call some tuple methods recursively without knowing the underlying types.
/// </summary>
internal interface ITupleInternal : ITuple
{
    string ToString(StringBuilder sb);
    int GetHashCode(IEqualityComparer comparer);
}

public static class SerializableTuple
{
    public static SerializableTuple<T1> Create<T1>(T1 item1)
    {
        return new SerializableTuple<T1>(item1);
    }

    public static SerializableTuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
    {
        return new SerializableTuple<T1, T2>(item1, item2);
    }

    public static SerializableTuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    {
        return new SerializableTuple<T1, T2, T3>(item1, item2, item3);
    }

    public static SerializableTuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
    {
        return new SerializableTuple<T1, T2, T3, T4>(item1, item2, item3, item4);
    }

    public static SerializableTuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
    {
        return new SerializableTuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
    }

    public static SerializableTuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
    {
        return new SerializableTuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
    }

    public static SerializableTuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
    {
        return new SerializableTuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
    }

    public static SerializableTuple<T1, T2, T3, T4, T5, T6, T7, SerializableTuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
    {
        return new SerializableTuple<T1, T2, T3, T4, T5, T6, T7, SerializableTuple<T8>>(item1, item2, item3, item4, item5, item6, item7, new SerializableTuple<T8>(item8));
    }

    // From System.Web.Util.HashCodeCombiner
    internal static int CombineHashCodes(int h1, int h2)
    {
        return (((h1 << 5) + h1) ^ h2);
    }

    internal static int CombineHashCodes(int h1, int h2, int h3)
    {
        return CombineHashCodes(CombineHashCodes(h1, h2), h3);
    }

    internal static int CombineHashCodes(int h1, int h2, int h3, int h4)
    {
        return CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));
    }

    internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
    {
        return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
    }

    internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6)
    {
        return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
    }

    internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7)
    {
        return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));
    }

    internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8)
    {
        return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));
    }
}

[Serializable]
public class SerializableTuple<T1> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
{

    [field:UnityEngine.SerializeField] public T1 Item1 { get; private set; }

    public SerializableTuple(T1 item1)
    {
        Item1 = item1;
    }

    public override Boolean Equals(Object obj)
    {
        return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
    }

    Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer)
    {
        if (other == null)
            return false;

        SerializableTuple<T1> objTuple = other as SerializableTuple<T1>;

        if (objTuple == null)
        {
            return false;
        }

        return comparer.Equals(Item1, objTuple.Item1);
    }

    Int32 IComparable.CompareTo(Object obj)
    {
        return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
    }

    Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer)
    {
        if (other == null)
            return 1;

        SerializableTuple<T1> objTuple = other as SerializableTuple<T1>;

        if (objTuple == null)
        {
            throw new ArgumentException();
        }

        return comparer.Compare(Item1, objTuple.Item1);
    }

    public override int GetHashCode()
    {
        return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
    }

    Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
        return comparer.GetHashCode(Item1);
    }

    Int32 ITupleInternal.GetHashCode(IEqualityComparer comparer)
    {
        return ((IStructuralEquatable)this).GetHashCode(comparer);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("(");
        return ((ITupleInternal)this).ToString(sb);
    }

    string ITupleInternal.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(")");
        return sb.ToString();
    }

    /// <summary>
    /// The number of positions in this data structure.
    /// </summary>
    int ITuple.Length => 1;

    /// <summary>
    /// Get the element at position <param name="index"/>.
    /// </summary>
    object ITuple.this[int index]
    {
        get
        {
            if (index != 0)
            {
                throw new IndexOutOfRangeException();
            }
            return Item1;
        }
    }

    public void Deconstruct(out T1 item1) => item1 = Item1;

    public Tuple<T1> ToTuple() => Tuple.Create(Item1);
    public ValueTuple<T1> ToValueTuple() => ValueTuple.Create(Item1);
}

[Serializable]
public class SerializableTuple<T1, T2> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
{

    [field:UnityEngine.SerializeField]public T1 Item1 { get; private set; }
    [field:UnityEngine.SerializeField]public T2 Item2 { get; private set; }

    public SerializableTuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }

    public override Boolean Equals(Object obj)
    {
        return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        ;
    }

    Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer)
    {
        if (other == null)
            return false;

        SerializableTuple<T1, T2> objTuple = other as SerializableTuple<T1, T2>;

        if (objTuple == null)
        {
            return false;
        }

        return comparer.Equals(Item1, objTuple.Item1) && comparer.Equals(Item2, objTuple.Item2);
    }

    Int32 IComparable.CompareTo(Object obj)
    {
        return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
    }

    Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer)
    {
        if (other == null)
            return 1;

        SerializableTuple<T1, T2> objTuple = other as SerializableTuple<T1, T2>;

        if (objTuple == null)
        {
            throw new ArgumentException();
        }

        int c = 0;

        c = comparer.Compare(Item1, objTuple.Item1);

        if (c != 0)
            return c;

        return comparer.Compare(Item2, objTuple.Item2);
    }

    public override int GetHashCode()
    {
        return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
    }

    Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
        return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2));
    }

    Int32 ITupleInternal.GetHashCode(IEqualityComparer comparer)
    {
        return ((IStructuralEquatable)this).GetHashCode(comparer);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("(");
        return ((ITupleInternal)this).ToString(sb);
    }

    string ITupleInternal.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(")");
        return sb.ToString();
    }

    /// <summary>
    /// The number of positions in this data structure.
    /// </summary>
    int ITuple.Length => 2;

    /// <summary>
    /// Get the element at position <param name="index"/>.
    /// </summary>
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

    public void Deconstruct(out T1 item1) => item1 = Item1;
    public void Deconstruct(out T1 item1, out T2 item2) => (item1, item2) = (Item1, Item2);
    public Tuple<T1,T2> ToTuple() => Tuple.Create(Item1, Item2);
    public ValueTuple<T1, T2> ToValueTuple() => ValueTuple.Create(Item1,Item2);
}

[Serializable]
public class SerializableTuple<T1, T2, T3> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
{
    [field:UnityEngine.SerializeField]public T1 Item1 { get; private set; }
    [field:UnityEngine.SerializeField]public T2 Item2 { get; private set; }
    [field:UnityEngine.SerializeField]public T3 Item3 { get; private set; }

    public SerializableTuple(T1 item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
    }

    public override Boolean Equals(Object obj)
    {
        return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        ;
    }

    Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer)
    {
        if (other == null)
            return false;

        SerializableTuple<T1, T2, T3> objTuple = other as SerializableTuple<T1, T2, T3>;

        if (objTuple == null)
        {
            return false;
        }

        return comparer.Equals(Item1, objTuple.Item1) && comparer.Equals(Item2, objTuple.Item2) && comparer.Equals(Item3, objTuple.Item3);
    }

    Int32 IComparable.CompareTo(Object obj)
    {
        return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
    }

    Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer)
    {
        if (other == null)
            return 1;

        SerializableTuple<T1, T2, T3> objTuple = other as SerializableTuple<T1, T2, T3>;

        if (objTuple == null)
        {
            throw new ArgumentException();
        }

        int c = 0;

        c = comparer.Compare(Item1, objTuple.Item1);

        if (c != 0)
            return c;

        c = comparer.Compare(Item2, objTuple.Item2);

        if (c != 0)
            return c;

        return comparer.Compare(Item3, objTuple.Item3);
    }

    public override int GetHashCode()
    {
        return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
    }

    Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
        return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3));
    }

    Int32 ITupleInternal.GetHashCode(IEqualityComparer comparer)
    {
        return ((IStructuralEquatable)this).GetHashCode(comparer);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("(");
        return ((ITupleInternal)this).ToString(sb);
    }

    string ITupleInternal.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(")");
        return sb.ToString();
    }

    /// <summary>
    /// The number of positions in this data structure.
    /// </summary>
    int ITuple.Length => 3;

    /// <summary>
    /// Get the element at position <param name="index"/>.
    /// </summary>
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
                case 2:
                    return Item3;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    public void Deconstruct(out T1 item1) => item1 = Item1;
    public void Deconstruct(out T1 item1, out T2 item2) => (item1, item2) = (Item1, Item2);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3) => (item1, item2, item3) = (Item1, Item2, Item3);
    public Tuple<T1, T2, T3> ToTuple() => Tuple.Create(Item1, Item2, Item3);
    public ValueTuple<T1, T2, T3> ToValueTuple() => ValueTuple.Create(Item1, Item2, Item3);
}

[Serializable]
public class SerializableTuple<T1, T2, T3, T4> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
{
    [field:UnityEngine.SerializeField]public T1 Item1 { get; private set; }
    [field:UnityEngine.SerializeField]public T2 Item2 { get; private set; }
    [field:UnityEngine.SerializeField]public T3 Item3 { get; private set; }
    [field:UnityEngine.SerializeField]public T4 Item4 { get; private set; }

    public SerializableTuple(T1 item1, T2 item2, T3 item3, T4 item4)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
    }

    public override Boolean Equals(Object obj)
    {
        return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        ;
    }

    Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer)
    {
        if (other == null)
            return false;

        SerializableTuple<T1, T2, T3, T4> objTuple = other as SerializableTuple<T1, T2, T3, T4>;

        if (objTuple == null)
        {
            return false;
        }

        return comparer.Equals(Item1, objTuple.Item1) && comparer.Equals(Item2, objTuple.Item2) && comparer.Equals(Item3, objTuple.Item3) && comparer.Equals(Item4, objTuple.Item4);
    }

    Int32 IComparable.CompareTo(Object obj)
    {
        return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
    }

    Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer)
    {
        if (other == null)
            return 1;

        SerializableTuple<T1, T2, T3, T4> objTuple = other as SerializableTuple<T1, T2, T3, T4>;

        if (objTuple == null)
        {
            throw new ArgumentException();
        }

        int c = 0;

        c = comparer.Compare(Item1, objTuple.Item1);

        if (c != 0)
            return c;

        c = comparer.Compare(Item2, objTuple.Item2);

        if (c != 0)
            return c;

        c = comparer.Compare(Item3, objTuple.Item3);

        if (c != 0)
            return c;

        return comparer.Compare(Item4, objTuple.Item4);
    }

    public override int GetHashCode()
    {
        return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
    }

    Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
        return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4));
    }

    Int32 ITupleInternal.GetHashCode(IEqualityComparer comparer)
    {
        return ((IStructuralEquatable)this).GetHashCode(comparer);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("(");
        return ((ITupleInternal)this).ToString(sb);
    }

    string ITupleInternal.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(")");
        return sb.ToString();
    }

    /// <summary>
    /// The number of positions in this data structure.
    /// </summary>
    int ITuple.Length => 4;

    /// <summary>
    /// Get the element at position <param name="index"/>.
    /// </summary>
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
                case 2:
                    return Item3;
                case 3:
                    return Item4;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    public void Deconstruct(out T1 item1) => item1 = Item1;
    public void Deconstruct(out T1 item1, out T2 item2) => (item1, item2) = (Item1, Item2);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3) => (item1, item2, item3) = (Item1, Item2, Item3);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4) => (item1, item2, item3, item4) = (Item1, Item2, Item3, Item4);
    public Tuple<T1, T2, T3, T4> ToTuple() => Tuple.Create(Item1, Item2, Item3, Item4);
    public ValueTuple<T1, T2, T3, T4> ToValueTuple() => ValueTuple.Create(Item1, Item2, Item3, Item4);
}

[Serializable]
public class SerializableTuple<T1, T2, T3, T4, T5> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
{
    [field:UnityEngine.SerializeField]public T1 Item1 { get; private set; }
    [field:UnityEngine.SerializeField]public T2 Item2 { get; private set; }
    [field:UnityEngine.SerializeField]public T3 Item3 { get; private set; }
    [field:UnityEngine.SerializeField]public T4 Item4 { get; private set; }
    [field:UnityEngine.SerializeField]public T5 Item5 { get; private set; }

    public SerializableTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
    }

    public override Boolean Equals(Object obj)
    {
        return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        ;
    }

    Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer)
    {
        if (other == null)
            return false;

        SerializableTuple<T1, T2, T3, T4, T5> objTuple = other as SerializableTuple<T1, T2, T3, T4, T5>;

        if (objTuple == null)
        {
            return false;
        }

        return comparer.Equals(Item1, objTuple.Item1) && comparer.Equals(Item2, objTuple.Item2) && comparer.Equals(Item3, objTuple.Item3) && comparer.Equals(Item4, objTuple.Item4) && comparer.Equals(Item5, objTuple.Item5);
    }

    Int32 IComparable.CompareTo(Object obj)
    {
        return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
    }

    Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer)
    {
        if (other == null)
            return 1;

        SerializableTuple<T1, T2, T3, T4, T5> objTuple = other as SerializableTuple<T1, T2, T3, T4, T5>;

        if (objTuple == null)
        {
            throw new ArgumentException();
        }

        int c = 0;

        c = comparer.Compare(Item1, objTuple.Item1);

        if (c != 0)
            return c;

        c = comparer.Compare(Item2, objTuple.Item2);

        if (c != 0)
            return c;

        c = comparer.Compare(Item3, objTuple.Item3);

        if (c != 0)
            return c;

        c = comparer.Compare(Item4, objTuple.Item4);

        if (c != 0)
            return c;

        return comparer.Compare(Item5, objTuple.Item5);
    }

    public override int GetHashCode()
    {
        return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
    }

    Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
        return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5));
    }

    Int32 ITupleInternal.GetHashCode(IEqualityComparer comparer)
    {
        return ((IStructuralEquatable)this).GetHashCode(comparer);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("(");
        return ((ITupleInternal)this).ToString(sb);
    }

    string ITupleInternal.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(")");
        return sb.ToString();
    }

    /// <summary>
    /// The number of positions in this data structure.
    /// </summary>
    int ITuple.Length => 5;

    /// <summary>
    /// Get the element at position <param name="index"/>.
    /// </summary>
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
                case 2:
                    return Item3;
                case 3:
                    return Item4;
                case 4:
                    return Item5;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
    public void Deconstruct(out T1 item1) => item1 = Item1;
    public void Deconstruct(out T1 item1, out T2 item2) => (item1, item2) = (Item1, Item2);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3) => (item1, item2, item3) = (Item1, Item2, Item3);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4) => (item1, item2, item3, item4) = (Item1, Item2, Item3, Item4);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5) => (item1, item2, item3, item4, item5) = (Item1, Item2, Item3, Item4, Item5);
    public Tuple<T1, T2, T3, T4, T5> ToTuple() => Tuple.Create(Item1, Item2, Item3, Item4, Item5);
    public ValueTuple<T1, T2, T3, T4, T5> ToValueTuple() => ValueTuple.Create(Item1, Item2, Item3, Item4, Item5);
}

[Serializable]
public class SerializableTuple<T1, T2, T3, T4, T5, T6> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
{
    [field:UnityEngine.SerializeField]public T1 Item1 { get; private set; }
    [field:UnityEngine.SerializeField]public T2 Item2 { get; private set; }
    [field:UnityEngine.SerializeField]public T3 Item3 { get; private set; }
    [field:UnityEngine.SerializeField]public T4 Item4 { get; private set; }
    [field:UnityEngine.SerializeField]public T5 Item5 { get; private set; }
    [field:UnityEngine.SerializeField]public T6 Item6 { get; private set; }

    public SerializableTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
        Item6 = item6;
    }

    public override Boolean Equals(Object obj)
    {
        return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        ;
    }

    Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer)
    {
        if (other == null)
            return false;

        SerializableTuple<T1, T2, T3, T4, T5, T6> objTuple = other as SerializableTuple<T1, T2, T3, T4, T5, T6>;

        if (objTuple == null)
        {
            return false;
        }

        return comparer.Equals(Item1, objTuple.Item1) && comparer.Equals(Item2, objTuple.Item2) && comparer.Equals(Item3, objTuple.Item3) && comparer.Equals(Item4, objTuple.Item4) && comparer.Equals(Item5, objTuple.Item5) && comparer.Equals(Item6, objTuple.Item6);
    }

    Int32 IComparable.CompareTo(Object obj)
    {
        return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
    }

    Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer)
    {
        if (other == null)
            return 1;

        SerializableTuple<T1, T2, T3, T4, T5, T6> objTuple = other as SerializableTuple<T1, T2, T3, T4, T5, T6>;

        if (objTuple == null)
        {
            throw new ArgumentException();
        }

        int c = 0;

        c = comparer.Compare(Item1, objTuple.Item1);

        if (c != 0)
            return c;

        c = comparer.Compare(Item2, objTuple.Item2);

        if (c != 0)
            return c;

        c = comparer.Compare(Item3, objTuple.Item3);

        if (c != 0)
            return c;

        c = comparer.Compare(Item4, objTuple.Item4);

        if (c != 0)
            return c;

        c = comparer.Compare(Item5, objTuple.Item5);

        if (c != 0)
            return c;

        return comparer.Compare(Item6, objTuple.Item6);
    }

    public override int GetHashCode()
    {
        return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
    }

    Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
        return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6));
    }

    Int32 ITupleInternal.GetHashCode(IEqualityComparer comparer)
    {
        return ((IStructuralEquatable)this).GetHashCode(comparer);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("(");
        return ((ITupleInternal)this).ToString(sb);
    }

    string ITupleInternal.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(")");
        return sb.ToString();
    }

    /// <summary>
    /// The number of positions in this data structure.
    /// </summary>
    int ITuple.Length => 6;

    /// <summary>
    /// Get the element at position <param name="index"/>.
    /// </summary>
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
                case 2:
                    return Item3;
                case 3:
                    return Item4;
                case 4:
                    return Item5;
                case 5:
                    return Item6;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    public void Deconstruct(out T1 item1) => item1 = Item1;
    public void Deconstruct(out T1 item1, out T2 item2) => (item1, item2) = (Item1, Item2);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3) => (item1, item2, item3) = (Item1, Item2, Item3);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4) => (item1, item2, item3, item4) = (Item1, Item2, Item3, Item4);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5) => (item1, item2, item3, item4, item5) = (Item1, Item2, Item3, Item4, Item5);

    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6) => (item1, item2, item3, item4, item5, item6) = 
                                                                                                                   (Item1, Item2, Item3, Item4, Item5, Item6);
    public Tuple<T1, T2, T3, T4, T5, T6> ToTuple() => Tuple.Create(Item1, Item2, Item3, Item4, Item5, Item6);
    public ValueTuple<T1, T2, T3, T4, T5, T6> ToValueTuple() => ValueTuple.Create(Item1, Item2, Item3, Item4, Item5, Item6);
}

[Serializable]
public class SerializableTuple<T1, T2, T3, T4, T5, T6, T7> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
{
    [field:UnityEngine.SerializeField]public T1 Item1 { get; private set; }
    [field:UnityEngine.SerializeField]public T2 Item2 { get; private set; }
    [field:UnityEngine.SerializeField]public T3 Item3 { get; private set; }
    [field:UnityEngine.SerializeField]public T4 Item4 { get; private set; }
    [field:UnityEngine.SerializeField]public T5 Item5 { get; private set; }
    [field:UnityEngine.SerializeField]public T6 Item6 { get; private set; }
    [field:UnityEngine.SerializeField]public T7 Item7 { get; private set; }

    public SerializableTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
        Item6 = item6;
        Item7 = item7;
    }

    public override Boolean Equals(Object obj)
    {
        return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        ;
    }

    Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer)
    {
        if (other == null)
            return false;

        SerializableTuple<T1, T2, T3, T4, T5, T6, T7> objTuple = other as SerializableTuple<T1, T2, T3, T4, T5, T6, T7>;

        if (objTuple == null)
        {
            return false;
        }

        return comparer.Equals(Item1, objTuple.Item1) && comparer.Equals(Item2, objTuple.Item2) && comparer.Equals(Item3, objTuple.Item3) && comparer.Equals(Item4, objTuple.Item4) && comparer.Equals(Item5, objTuple.Item5) && comparer.Equals(Item6, objTuple.Item6) && comparer.Equals(Item7, objTuple.Item7);
    }

    Int32 IComparable.CompareTo(Object obj)
    {
        return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
    }

    Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer)
    {
        if (other == null)
            return 1;

        SerializableTuple<T1, T2, T3, T4, T5, T6, T7> objTuple = other as SerializableTuple<T1, T2, T3, T4, T5, T6, T7>;

        if (objTuple == null)
        {
            throw new ArgumentException();
        }

        int c = 0;

        c = comparer.Compare(Item1, objTuple.Item1);

        if (c != 0)
            return c;

        c = comparer.Compare(Item2, objTuple.Item2);

        if (c != 0)
            return c;

        c = comparer.Compare(Item3, objTuple.Item3);

        if (c != 0)
            return c;

        c = comparer.Compare(Item4, objTuple.Item4);

        if (c != 0)
            return c;

        c = comparer.Compare(Item5, objTuple.Item5);

        if (c != 0)
            return c;

        c = comparer.Compare(Item6, objTuple.Item6);

        if (c != 0)
            return c;

        return comparer.Compare(Item7, objTuple.Item7);
    }

    public override int GetHashCode()
    {
        return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
    }

    Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
        return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7));
    }

    Int32 ITupleInternal.GetHashCode(IEqualityComparer comparer)
    {
        return ((IStructuralEquatable)this).GetHashCode(comparer);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("(");
        return ((ITupleInternal)this).ToString(sb);
    }

    string ITupleInternal.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(", ");
        sb.Append(Item7);
        sb.Append(")");
        return sb.ToString();
    }

    /// <summary>
    /// The number of positions in this data structure.
    /// </summary>
    int ITuple.Length => 7;

    /// <summary>
    /// Get the element at position <param name="index"/>.
    /// </summary>
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
                case 2:
                    return Item3;
                case 3:
                    return Item4;
                case 4:
                    return Item5;
                case 5:
                    return Item6;
                case 6:
                    return Item7;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
    public void Deconstruct(out T1 item1) => item1 = Item1;
    public void Deconstruct(out T1 item1, out T2 item2) => (item1, item2) = (Item1, Item2);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3) => (item1, item2, item3) = (Item1, Item2, Item3);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4) => (item1, item2, item3, item4) = (Item1, Item2, Item3, Item4);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5) => (item1, item2, item3, item4, item5) = (Item1, Item2, Item3, Item4, Item5);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6) => (item1, item2, item3, item4, item5, item6) =
                                                                                                                   (Item1, Item2, Item3, Item4, Item5, Item6);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7) => 
        (item1, item2, item3, item4, item5, item6, item7) = 
        (Item1, Item2, Item3, Item4, Item5, Item6, Item7);
    public Tuple<T1, T2, T3, T4, T5, T6, T7> ToTuple() => Tuple.Create(Item1, Item2, Item3, Item4, Item5, Item6, Item7);
    public ValueTuple<T1, T2, T3, T4, T5,T6,T7> ToValueTuple() => ValueTuple.Create(Item1, Item2, Item3, Item4, Item5, Item6, Item7);
}


[Serializable]
public class SerializableTuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
{
    [field:UnityEngine.SerializeField]public T1 Item1 { get; private set; }
    [field:UnityEngine.SerializeField]public T2 Item2 { get; private set; }
    [field:UnityEngine.SerializeField]public T3 Item3 { get; private set; }
    [field:UnityEngine.SerializeField]public T4 Item4 { get; private set; }
    [field:UnityEngine.SerializeField]public T5 Item5 { get; private set; }
    [field:UnityEngine.SerializeField]public T6 Item6 { get; private set; }
    [field:UnityEngine.SerializeField]public T7 Item7 { get; private set; }
    [field:UnityEngine.SerializeField]public TRest Rest { get; private set; }

    public SerializableTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
    {
        if (!(rest is ITupleInternal))
        {
            throw new ArgumentException();
        }

        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
        Item6 = item6;
        Item7 = item7;
        Rest = rest;
    }

    public override Boolean Equals(Object obj)
    {
        return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        ;
    }

    Boolean IStructuralEquatable.Equals(Object other, IEqualityComparer comparer)
    {
        if (other == null)
            return false;

        SerializableTuple<T1, T2, T3, T4, T5, T6, T7, TRest> objTuple = other as SerializableTuple<T1, T2, T3, T4, T5, T6, T7, TRest>;

        if (objTuple == null)
        {
            return false;
        }

        return comparer.Equals(Item1, objTuple.Item1) && comparer.Equals(Item2, objTuple.Item2) && comparer.Equals(Item3, objTuple.Item3) && comparer.Equals(Item4, objTuple.Item4) && comparer.Equals(Item5, objTuple.Item5) && comparer.Equals(Item6, objTuple.Item6) && comparer.Equals(Item7, objTuple.Item7) && comparer.Equals(Rest, objTuple.Rest);
    }

    Int32 IComparable.CompareTo(Object obj)
    {
        return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
    }

    Int32 IStructuralComparable.CompareTo(Object other, IComparer comparer)
    {
        if (other == null)
            return 1;

        SerializableTuple<T1, T2, T3, T4, T5, T6, T7, TRest> objTuple = other as SerializableTuple<T1, T2, T3, T4, T5, T6, T7, TRest>;

        if (objTuple == null)
        {
            throw new ArgumentException();
        }

        int c = 0;

        c = comparer.Compare(Item1, objTuple.Item1);

        if (c != 0)
            return c;

        c = comparer.Compare(Item2, objTuple.Item2);

        if (c != 0)
            return c;

        c = comparer.Compare(Item3, objTuple.Item3);

        if (c != 0)
            return c;

        c = comparer.Compare(Item4, objTuple.Item4);

        if (c != 0)
            return c;

        c = comparer.Compare(Item5, objTuple.Item5);

        if (c != 0)
            return c;

        c = comparer.Compare(Item6, objTuple.Item6);

        if (c != 0)
            return c;

        c = comparer.Compare(Item7, objTuple.Item7);

        if (c != 0)
            return c;

        return comparer.Compare(Rest, objTuple.Rest);
    }

    public override int GetHashCode()
    {
        return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
    }

    Int32 IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
        // We want to have a limited hash in this case.  We'll use the last 8 elements of the tuple
        ITupleInternal t = (ITupleInternal)Rest;
        if (t.Length >= 8)
        { return t.GetHashCode(comparer); }

        // In this case, the rest memeber has less than 8 elements so we need to combine some our elements with the elements in rest
        int k = 8 - t.Length;
        switch (k)
        {
            case 1:
                return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item7), t.GetHashCode(comparer));
            case 2:
                return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), t.GetHashCode(comparer));
            case 3:
                return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), t.GetHashCode(comparer));
            case 4:
                return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), t.GetHashCode(comparer));
            case 5:
                return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), t.GetHashCode(comparer));
            case 6:
                return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), t.GetHashCode(comparer));
            case 7:
                return SerializableTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), t.GetHashCode(comparer));
        }
        Contract.Assert(false, "Missed all cases for computing Tuple hash code");
        return -1;
    }

    Int32 ITupleInternal.GetHashCode(IEqualityComparer comparer)
    {
        return ((IStructuralEquatable)this).GetHashCode(comparer);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("(");
        return ((ITupleInternal)this).ToString(sb);
    }

    string ITupleInternal.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(", ");
        sb.Append(Item7);
        sb.Append(", ");
        return ((ITupleInternal)Rest).ToString(sb);
    }

    /// <summary>
    /// The number of positions in this data structure.
    /// </summary>
    int ITuple.Length
    {
        get
        {
            return 7 + ((ITupleInternal)Rest).Length;
        }
    }

    /// <summary>
    /// Get the element at position <param name="index"/>.
    /// </summary>
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
                case 2:
                    return Item3;
                case 3:
                    return Item4;
                case 4:
                    return Item5;
                case 5:
                    return Item6;
                case 6:
                    return Item7;
            }

            return ((ITupleInternal)Rest)[index - 7];
        }
    }

   // public Tuple<T1, T2, T3, T4, T5, T6, T7, dynamic> ToTuple()
   // {
   //     //throw new NotImplementedException();
   //     var tuple = (ITupleInternal)this;
   //     const int MAX_TUPLE_ITEMS = 7;
   //
   //     int lastIter = tuple.Length - (tuple.Length % MAX_TUPLE_ITEMS);
   //     ITuple finalInnerTuple = null;
   //     switch (tuple.Length - lastIter)
   //     {
   //         case 0:
   //             break;
   //         case 1:
   //             finalInnerTuple = Tuple.Create(tuple[lastIter]);
   //             break;
   //         case 2:
   //             finalInnerTuple = Tuple.Create(tuple[lastIter], tuple[lastIter + 1]);
   //             break;
   //         case 3:
   //             finalInnerTuple = Tuple.Create(tuple[lastIter], tuple[lastIter + 1], tuple[lastIter + 2]);
   //             break;
   //         case 4:
   //             finalInnerTuple = Tuple.Create(tuple[lastIter], tuple[lastIter + 1], tuple[lastIter + 2], tuple[lastIter + 3]);
   //             break;
   //         case 5:
   //             finalInnerTuple = Tuple.Create(tuple[lastIter], tuple[lastIter + 1], tuple[lastIter + 2], tuple[lastIter + 3], tuple[lastIter + 4]);
   //             break;
   //         case 6:
   //             finalInnerTuple = Tuple.Create(tuple[lastIter], tuple[lastIter + 1], tuple[lastIter + 2], tuple[lastIter + 3], tuple[lastIter + 4], tuple[lastIter + 5]);
   //             break;
   //     }
   //
   //     ITuple innerTuple = null;
   //     for (int i = 0; i < tuple.Length / MAX_TUPLE_ITEMS - 1; i++)
   //     {
   //         int curGroup = i * MAX_TUPLE_ITEMS;
   //         if (i == 0)
   //         {
   //             innerTuple = new Tuple<object, object, object, object, object, object, object, ITuple>(
   //                 tuple[0 + curGroup], tuple[1 + curGroup], tuple[2 + curGroup], tuple[3 + curGroup],
   //                 tuple[4 + curGroup], tuple[5 + curGroup], tuple[6 + curGroup], finalInnerTuple);
   //             continue;
   //         }
   //         innerTuple = new Tuple<object,object,object,object,object,object,object,ITuple>(
   //                 tuple[0 + curGroup], tuple[1 + curGroup], tuple[2 + curGroup], tuple[3 + curGroup],
   //                 tuple[4 + curGroup], tuple[5 + curGroup], tuple[6 + curGroup], innerTuple);
   //     }
   //     return Tuple.Create(this.Item1, this.Item2, this.Item3, this.Item4, this.Item5, this.Item6, this.Item7, innerTuple);
   // }

    public void Deconstruct(out T1 item1) => item1 = Item1;
    public void Deconstruct(out T1 item1, out T2 item2) => (item1, item2) = (Item1, Item2);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3) => (item1, item2, item3) = (Item1, Item2, Item3);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4) => (item1, item2, item3, item4) = (Item1, Item2, Item3, Item4);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5) => (item1, item2, item3, item4, item5) = (Item1, Item2, Item3, Item4, Item5);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6) => (item1, item2, item3, item4, item5, item6) =
                                                                                                                   (Item1, Item2, Item3, Item4, Item5, Item6);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7) =>
        (item1, item2, item3, item4, item5, item6, item7) =
        (Item1, Item2, Item3, Item4, Item5, Item6, Item7);
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7, out dynamic[] restItems)
    {
        (item1, item2, item3, item4, item5, item6, item7) =
        (Item1, Item2, Item3, Item4, Item5, Item6, Item7);

        var tuple = (ITupleInternal)Rest;
        restItems = new dynamic[tuple.Length];
        for (int i = 0; i < restItems.Length; i++)
        {
            restItems[i] = tuple[i];
        }
    }
    public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7, out TRest rest) =>
        (item1, item2, item3, item4, item5, item6, item7, rest) =
        (Item1, Item2, Item3, Item4, Item5, Item6, Item7, Rest);
    public (Tuple<T1, T2, T3, T4, T5, T6, T7>Tuple, TRest SerializableTuple) ToTuple() => (Tuple.Create(Item1, Item2, Item3, Item4, Item5, Item6, Item7), Rest);
    public (ValueTuple<T1, T2, T3, T4, T5, T6, T7> ValueTuple, TRest SerializableTuple) ToValueTuple() => (ValueTuple.Create(Item1, Item2, Item3, Item4, Item5, Item6, Item7), Rest);
}

