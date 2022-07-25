#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Diagnostics.Contracts;
using UnityEngine;
using static LanguageExt.Prelude;
using static NullBool.ConstLib;

namespace NullBool.Extensions
{
    public static class ScriptableObjectExtensions
    {

        /// <summary>
        /// Creates an asset at "<paramref name="assetPath"/>/<paramref name="assetName"/>.asset"
        /// </summary>
        /// <param name="assetPath"></param>
        /// <param name="assetName">if <see langword="null"/> defaults to:<br /> <see cref="typeof"/>(<typeparamref name="T"/>).<see cref="System.Type.ToString()">ToString</see>()></param>
        /// <returns>Asset of type: <typeparamref name="T"/></returns>
        /// <remarks>
        /// if <paramref name="assetName"/> is <see langword="null"/> defaults to:<br /> <see cref="typeof"/>(<typeparamref name="T"/>).<see cref="System.Type.ToString()">ToString</see>()><para />
        /// 
        /// Similar methods of interest:<br />
        /// <see cref="LoadAsset{T}(T, string, bool)"><c>LoadAsset</c></see><c>(<see cref="string"/>, <see cref="bool"/>)</c><br />
        /// <see cref="LoadOrCreateAsset{T}(T, string, bool, string)"/><br />
        /// </remarks>
        [Pure]
        public static T CreateAsset<T>(this T @this,string assetPath, string assetName = null) where T : ScriptableObject
            => CreateAsset<T>(assetPath, assetName);

        /// <returns>Asset of type: <typeparamref name="T"/></returns>
        /// <inheritdoc cref="CreateAsset{T}(T, string, string)"/>
        [Pure]
        public static T CreateAsset<T>(string assetPath, string assetName = null) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();

            #if UNITY_EDITOR
            assetName ??= typeof(T).ToString();

            string[] folders = assetPath.Split("/");
            for (int i = 0; i < folders.Length; i++)
            {
                int previousFolderIndex = i > 0 ? i - 1 : 0;

                string iterFolderPath = string.Join('/', folders[0..(previousFolderIndex)]);

                if (!AssetDatabase.IsValidFolder($"{iterFolderPath}/{folders[i]}"))
                    AssetDatabase.CreateFolder(iterFolderPath, folders[i]);
            }

            AssetDatabase.CreateAsset(asset, $"{assetPath}/{assetName}.asset");
            AssetDatabase.SaveAssets();
            #endif

            return asset;
        }

        /// <summary>
        /// Loads asset at <c>"<see cref="RESOURCES">Resources</see>||<see cref="EDITOR_DEFAULT_RESOURCES">Editor Default Resources</see>/<paramref name="assetLocation"/>"</c>
        /// </summary>
        /// <returns>Asset of type: <typeparamref name="T"/></returns>
        [Pure]
        public static T LoadAsset<T>(string assetLocation, bool useEditorDefaultResourceFolder = false) where T : ScriptableObject
            => LoadAsset<T>(null, assetLocation, useEditorDefaultResourceFolder);


        /// <returns>Asset of type: <typeparamref name="T"/></returns>
        /// <inheritdoc cref="LoadAsset{T}(T, string, bool)"/>
        [Pure]
        #if UNITY_EDITOR
        public static T LoadAsset<T>(this T @this,string assetLocation, bool useEditorDefaultResourceFolder = false) where T : ScriptableObject
            => useEditorDefaultResourceFolder ? (T)EditorGUIUtility.Load(assetLocation) : (T)Resources.Load(assetLocation);
        #else
        public static T LoadAsset<T>(this T @this, string assetLocation, bool useEditorDefaultResourceFolder = false) where T : ScriptableObject
            => Optional((T)Resources.Load(assetLocation)).IfNone(ScriptableObject.CreateInstance<T>());
        #endif


        /// <summary>
        /// if <see cref="LoadAsset(string, bool)">LoadAsset</see>(<see cref="string"/> <paramref name="assetPath"/>.<see cref="string.Split(char[])">Split</see>(AtResourceFolder), <see cref="bool"/> <paramref name="useEditorDefaultResourceFolder"/>)<br /> 
        /// returns <see langword="null"/> call <see cref="CreateAsset{T}(T, string, string)">Create</see>(<see cref="string"/> <paramref name="assetPath"/>, <see cref="string"/> <paramref name="assetName"/>)
        /// </summary>
        /// <returns>Asset of type: <typeparamref name="T"/></returns>
        /// <remarks> if <paramref name="assetName"/> is <see langword="null"/> defaults to:<br /> <see cref="typeof"/>(<typeparamref name="T"/>).<see cref="System.Type.ToString()">ToString</see>()><para /></remarks>
        [Pure]
        public static T LoadOrCreateAsset<T>(string assetPath, bool useEditorDefaultResourceFolder = false, string assetName = null) where T : ScriptableObject
            => Optional<T>(LoadAsset<T>(assetPath.Split(useEditorDefaultResourceFolder ? EDITOR_DEFAULT_RESOURCES : RESOURCES, 1)[1])).
               IfNone(CreateAsset<T>(assetPath, assetName ??= typeof(T).ToString()));

        /// <returns>Asset of type: <typeparamref name="T"/></returns>
        /// <inheritdoc cref="LoadOrCreateAsset{T}(string, bool, string)"/>
        public static T LoadOrCreateAsset<T>(this T @this, string assetPath, bool useEditorDefaultResourceFolder = false, string assetName = null) where T : ScriptableObject
            => LoadOrCreateAsset<T>(assetPath, useEditorDefaultResourceFolder, assetName);
    }
}
