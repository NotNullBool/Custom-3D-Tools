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
//using LanguageExt;
//using static LanguageExt.Prelude;
using UnityEngine;
using UnityEditor;
using UniRx;
using System;
using UnityEngine.UIElements;
#endregion

[CustomEditor(typeof(MonoBehaviour),true)]
[CanEditMultipleObjects]
public class ObservableEditor : Editor
{
    #region Variables

    #endregion

    #region Methods
    [InitializeOnLoadMethod]
    static void OnLoad()
    {
        //Do something?
    }

    private static Subject<(SerializedObject SerializedObject, UnityEngine.Object Target)> _EveryCreateInspectorGUI = new Subject<(SerializedObject, UnityEngine.Object)> ();
    public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryCreateInspectorGUI = _EveryCreateInspectorGUI.AsObservable();

    public override VisualElement CreateInspectorGUI()
    {
        _EveryCreateInspectorGUI.OnNext((serializedObject, target));
        return base.CreateInspectorGUI();
    }

    private static Subject<(SerializedObject SerializedObject, UnityEngine.Object Target, Rect PreviewArea)> _EveryDrawPreview = new Subject<(SerializedObject, UnityEngine.Object, Rect)>();
    public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, Rect PreviewArea)> EveryDrawPreview = _EveryDrawPreview.AsObservable();

    public override void DrawPreview(Rect previewArea)
    {
        _EveryDrawPreview.OnNext((serializedObject, target, previewArea));
        base.DrawPreview(previewArea);
    }

    private static Subject<(SerializedObject SerializedObject, UnityEngine.Object Target)> _EveryGetInfoString = new Subject<(SerializedObject, UnityEngine.Object)>();
    public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryGetInfoString = _EveryGetInfoString.AsObservable();
    public override string GetInfoString()
    {
        _EveryGetInfoString.OnNext((serializedObject, target));
        return base.GetInfoString();
    }

    private static Subject<(SerializedObject SerializedObject, UnityEngine.Object Target)> _EveryGetPreviewTitle = new Subject<(SerializedObject, UnityEngine.Object)>();
    public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryGetPreviewTitle = _EveryGetPreviewTitle.AsObservable();

    public override GUIContent GetPreviewTitle()
    {
        _EveryGetPreviewTitle.OnNext((serializedObject, target));
        return base.GetPreviewTitle();
    }

    public override bool HasPreviewGUI()
    {
        return base.HasPreviewGUI();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
        base.OnInteractivePreviewGUI(r, background);
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        base.OnPreviewGUI(r, background);
    }

    public override void OnPreviewSettings()
    {
        base.OnPreviewSettings();
    }

    public override void ReloadPreviewInstances()
    {
        base.ReloadPreviewInstances();
    }

    public override Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets, int width, int height)
    {
        return base.RenderStaticPreview(assetPath, subAssets, width, height);
    }

    public override bool RequiresConstantRepaint()
    {
        return base.RequiresConstantRepaint();
    }

    public override bool UseDefaultMargins()
    {
        return base.UseDefaultMargins();
    }

    protected override void OnHeaderGUI()
    {
        base.OnHeaderGUI();
    }

    protected override bool ShouldHideOpenButton()
    {
        return base.ShouldHideOpenButton();
    }


    #endregion Methods
}