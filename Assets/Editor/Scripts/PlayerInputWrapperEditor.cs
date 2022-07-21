using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NewPlayerInputWrapper))]
public class PlayerInputWrapperEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.GetIterator();
        base.OnInspectorGUI();
    }
}
