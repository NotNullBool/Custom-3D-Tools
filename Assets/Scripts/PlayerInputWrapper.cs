#region Copyright (c)
/****************************************
 * Copyright (c) All rights reserved to
 * !NullBool, NotNullBool
 * Contact info: notnullbool@gmail.com
 ****************************************/
#endregion

#region Imports
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using LanguageExt;
using static LanguageExt.Prelude;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

using static UnityEngine.InputSystem.InputAction;
#endregion

[ExecuteInEditMode]
[RequireComponent(typeof(PlayerInput))]
public class PlayerInputWrapper : MonoBehaviour
{
    #region Variables
    private PlayerInput _PlayerScript;
    [SerializeField][NaughtyAttributes.Expandable] private InputSettings _Settings;
    #endregion

    #region Methods
    
    private void OnValidate()
    {
        _Settings = InputSettings.GetInstance<InputSettings>();
    }
    /// <summary>
    /// <see cref="Start"/> is called before the first frame update
    /// </summary>
    void Start()
    {
        _PlayerScript = Optional(_PlayerScript).
                        IfNoneUnsafe(GetComponent<PlayerInput>());
        _Settings.ApplyToPlayerInput(_PlayerScript);
        _PlayerScript.notificationBehavior = PlayerNotifications.InvokeCSharpEvents;
        //Debug.Log(null);
    }

    /// <summary>
    /// <see cref="Update"/> is called once per frame
    /// </summary>
    void Update()
    {
        #if UNITY_EDITOR
        //UpdateEditor();
        #endif
    }

    private void UpdateEditor() 
    {
       

        //Debug.Log();
    }

    //private void Reset()
    //{
    //    var playerInput = GetComponent<PlayerInput>();
    //    if (playerInput == null)
    //    {
    //        gameObject.AddComponent<PlayerInput>();
    //    }
    //    playerInput.hideFlags = HideFlags.HideInInspector;
    //}
    public void Fire(CallbackContext context) => Debug.Log($"action:{context.action.name}, type: {context.valueType}, performed: {context.phase}");

    #endregion Methods
}
