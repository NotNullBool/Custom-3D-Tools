#region Copyright (c)
/****************************************
 * Copyright (c) All rights reserved to
 * !NullBool, NotNullBool
 * Contact info: notnullbool@gmail.com
 ****************************************/
#endregion

namespace NullBool.UniEditor
{


    #if UNITY_EDITOR
    #region Imports
    using UnityEngine;
    using UnityEditor;
    using UniRx;
    using UnityEngine.UIElements;
    using System;
    #endregion

    [CustomEditor(typeof(MonoBehaviour),true)]
    [CanEditMultipleObjects()]
    public class ObservableEditor : Editor
    {
    #region Variables

    #endregion

    #region Methods

        private static Subject<(SerializedObject, UnityEngine.Object, VisualElement)> _EveryCreateInspectorGUI = new Subject<(SerializedObject, UnityEngine.Object, VisualElement)> ();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, VisualElement @base)> EveryCreateInspectorGUI = _EveryCreateInspectorGUI.AsObservable();

        public override VisualElement CreateInspectorGUI()
        {
            var @base = base.CreateInspectorGUI();
            _EveryCreateInspectorGUI.OnNext((serializedObject, target, @base));
            return @base;
        }

        private static Subject<(SerializedObject, UnityEngine.Object, Rect, Action<Rect>)> _EveryDrawPreview = new Subject<(SerializedObject, UnityEngine.Object, Rect, Action<Rect>)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, Rect PreviewArea, Action<Rect> @base)> EveryDrawPreview = _EveryDrawPreview.AsObservable();


        public override void DrawPreview(Rect previewArea)
        {
            Action<Rect> @base = previewArea => base.DrawPreview(previewArea);
            _EveryDrawPreview.OnNext((serializedObject, target, previewArea, @base));
            @base(previewArea);
        }


        private static Subject<(SerializedObject, UnityEngine.Object, Func<string>)> _EveryGetInfoString = new Subject<(SerializedObject, UnityEngine.Object, Func<string>)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, Func<string> @base)> EveryGetInfoString = _EveryGetInfoString.AsObservable();

        public override string GetInfoString()
        {
            Func<string> @base = () => base.GetInfoString();
            _EveryGetInfoString.OnNext((serializedObject, target, @base));
            return @base();
        }


        private static Subject<(SerializedObject, UnityEngine.Object, Func<GUIContent>)> _EveryGetPreviewTitle = new Subject<(SerializedObject, UnityEngine.Object, Func<GUIContent>)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, Func<GUIContent> @base)> EveryGetPreviewTitle = _EveryGetPreviewTitle.AsObservable();

        public override GUIContent GetPreviewTitle()
        {
            Func<GUIContent> @base = () => base.GetPreviewTitle();
            _EveryGetPreviewTitle.OnNext((serializedObject, target, @base));
            return @base();
        }

        private static Subject<(SerializedObject, UnityEngine.Object, bool)> _EveryHasPreviewGUI = new Subject<(SerializedObject, UnityEngine.Object, bool)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, bool @base)> EveryHasPreviewGUI = _EveryHasPreviewGUI.AsObservable();

        public override bool HasPreviewGUI()
        {
            var @base = base.HasPreviewGUI();
            _EveryHasPreviewGUI.OnNext((serializedObject, target, @base));
            return @base;
        }

        private static Subject<(SerializedObject, UnityEngine.Object[])> _EveryOnInspectorGUI = new Subject<(SerializedObject, UnityEngine.Object[])>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object[] Targets)> EveryOnInspectorGUI = _EveryOnInspectorGUI.AsObservable();

        public override void OnInspectorGUI()
        {
            _EveryOnInspectorGUI.OnNext((serializedObject, targets));
            base.OnInspectorGUI();
        }
        private static Subject<(SerializedObject, UnityEngine.Object, Rect, GUIStyle)> _EveryOnInteractivePreviewGUI = new Subject<(SerializedObject, UnityEngine.Object, Rect, GUIStyle)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, Rect R, GUIStyle Background)> EveryOnInteractivePreviewGUI = _EveryOnInteractivePreviewGUI.AsObservable();
        public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
        {
    #if UNITY_EDITOR
            _EveryOnInteractivePreviewGUI.OnNext((serializedObject, target, r, background));
    #endif
            base.OnInteractivePreviewGUI(r, background);
        }

        private static Subject<(UnityEngine.Object, Rect, GUIStyle)> _EveryOnPreviewGUI = new Subject<(UnityEngine.Object, Rect, GUIStyle)>();
        public static IObservable<(UnityEngine.Object Target, Rect R, GUIStyle Background)> EveryOnPreviewGUI = _EveryOnPreviewGUI.AsObservable();
        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            _EveryOnPreviewGUI.OnNext((target, r, background));
            base.OnPreviewGUI(r, background);
        }

        private static Subject<(SerializedObject, UnityEngine.Object)> _EveryOnPreviewSettings = new Subject<(SerializedObject, UnityEngine.Object)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryOnPreviewSettings = _EveryOnPreviewSettings.AsObservable();
        public override void OnPreviewSettings()
        {
            _EveryOnPreviewSettings.OnNext((serializedObject, target));
            base.OnPreviewSettings();
        }

        private static Subject<(SerializedObject, UnityEngine.Object)> _EveryReloadPreviewInstances = new Subject<(SerializedObject, UnityEngine.Object)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryReloadPreviewInstances = _EveryReloadPreviewInstances.AsObservable();
        public override void ReloadPreviewInstances()
        {
            _EveryReloadPreviewInstances.OnNext((serializedObject, target));
            base.ReloadPreviewInstances();
        }


        private static Subject<(SerializedObject, UnityEngine.Object, string, UnityEngine.Object[], int, int, Texture2D)> _EveryRenderStaticPreview = new Subject<(SerializedObject, UnityEngine.Object, string, UnityEngine.Object[], int, int, Texture2D)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, string AssetPath, UnityEngine.Object[] SubAssets, int Width, int Height, Texture2D @base)> EveryRenderStaticPreview = _EveryRenderStaticPreview.AsObservable();
        public override Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets, int width, int height)
        {
            var @base = base.RenderStaticPreview(assetPath, subAssets, width, height);
            _EveryRenderStaticPreview.OnNext((serializedObject, target, assetPath, subAssets, width, height, @base));
            return @base;
        }

        private static Subject<(SerializedObject, UnityEngine.Object, bool)> _EveryRequiresConstantRepaint = new Subject<(SerializedObject, UnityEngine.Object, bool)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, bool @base)> EveryRequiresConstantRepaint = _EveryRequiresConstantRepaint.AsObservable();
        public override bool RequiresConstantRepaint()
        {
            var @base = base.RequiresConstantRepaint();
            _EveryRequiresConstantRepaint.OnNext((serializedObject, target, @base));
            return @base;
        }

        private static Subject<(SerializedObject, UnityEngine.Object, bool)> _EveryUseDefaultMargins = new Subject<(SerializedObject, UnityEngine.Object, bool)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, bool @base)> EveryUseDefaultMargins = _EveryUseDefaultMargins.AsObservable();
        public override bool UseDefaultMargins()
        {
            var @base = base.UseDefaultMargins();
            _EveryUseDefaultMargins.OnNext((serializedObject, target, @base));
            return @base;
        }

        private static Subject<(SerializedObject, UnityEngine.Object, bool)> _EveryShouldHideOpenButton = new Subject<(SerializedObject, UnityEngine.Object, bool)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target, bool @base)> EveryShouldHideOpenButton = _EveryShouldHideOpenButton.AsObservable();
        protected override bool ShouldHideOpenButton()
        {
            var @base = base.ShouldHideOpenButton();
            _EveryShouldHideOpenButton.OnNext((serializedObject, target, @base));
            return @base;
        }

        private static Subject<(SerializedObject, UnityEngine.Object)> _EveryOnHeaderGUI = new Subject<(SerializedObject, UnityEngine.Object)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryOnHeaderGUI = _EveryOnHeaderGUI.AsObservable();
        protected override void OnHeaderGUI()
        {
            _EveryOnHeaderGUI.OnNext((serializedObject, target));
            base.OnHeaderGUI();
        }

        private static Subject<UnityEngine.Object> _EveryOnDestroy = new Subject<UnityEngine.Object>();
        public static IObservable<UnityEngine.Object> EveryOnDestroy = _EveryOnDestroy.AsObservable();
        private void OnDestroy()
        {
            _EveryOnDestroy.OnNext(target);
        }

        private static Subject<(SerializedObject, UnityEngine.Object)> _EveryOnEnable = new Subject<(SerializedObject, UnityEngine.Object)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryOnEnable = _EveryOnEnable.AsObservable();
        private void OnEnable()
        {
            _EveryOnEnable.OnNext((serializedObject, target));
        }

        private static Subject<(SerializedObject, UnityEngine.Object)> _EveryOnDisable = new Subject<(SerializedObject, UnityEngine.Object)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryOnDisable = _EveryOnDisable.AsObservable();
        private void OnDisable()
        {
            _EveryOnDisable.OnNext((serializedObject, target));
        }

        private static Subject<UnityEngine.Object> _EveryOnSceneGUI = new Subject<UnityEngine.Object>();
        public static IObservable<UnityEngine.Object> EveryOnSceneGUI = _EveryOnSceneGUI.AsObservable();
        private void OnSceneGUI()
        {
            _EveryOnSceneGUI.OnNext(target);
        }

        private static Subject<(SerializedObject, UnityEngine.Object)> _EveryOnValidate = new Subject<(SerializedObject, UnityEngine.Object)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryOnValidate = _EveryOnValidate.AsObservable();
        private void OnValidate()
        {
            _EveryOnValidate.OnNext((serializedObject, target));
        }

        private static Subject<(SerializedObject, UnityEngine.Object)> _EveryAwake = new Subject<(SerializedObject, UnityEngine.Object)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryAwake = _EveryAwake.AsObservable();
        private void Awake()
        {
            _EveryAwake.OnNext((serializedObject, target));
        }


        private static Subject<(SerializedObject, UnityEngine.Object)> _EveryReset = new Subject<(SerializedObject, UnityEngine.Object)>();
        public static IObservable<(SerializedObject SerializedObject, UnityEngine.Object Target)> EveryReset = _EveryReset.AsObservable();
        private void Reset()
        {
            _EveryReset.OnNext((serializedObject, target));
        }
    #endregion Methods
    }
    #endif
}