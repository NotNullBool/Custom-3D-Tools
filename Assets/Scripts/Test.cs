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

using UnityEngine;
using UnityEngine.InputSystem;

using static UnityEngine.InputSystem.InputAction;
#endregion

[RequireComponent(typeof(PlayerInput))]
public class Test : MonoBehaviour
{
    #region Variables
    private PlayerInput _PlayerScript;
    #endregion
    
    #region Methods
    /// <summary>
    /// <see cref="Start"/> is called before the first frame update
    /// </summary>
    void Start()
    {
        _PlayerScript = gameObject.GetComponent<PlayerInput>();
        _PlayerScript.notificationBehavior = PlayerNotifications.InvokeCSharpEvents;
        _PlayerScript.onActionTriggered += Fire;
    }

    /// <summary>
    /// <see cref="Update"/> is called once per frame
    /// </summary>
    void Update()
    {
        
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
