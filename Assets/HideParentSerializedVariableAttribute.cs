using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Class)]

public class HideParentSerializedVariableAttribute : Attribute
{
    public HideParentSerializedVariableAttribute()
    {
        Test test = new Test();
        test.GetType();
    }
}
