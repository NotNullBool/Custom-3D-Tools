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
using UniRx;
using UniRx.Triggers;

using UnityEditor.Presets;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;
#endregion

public class InputSettings : ScriptableObjectSingleton<InputSettings>
{
    #region Variables
    [Required("Input Action Asset Required")]
    [SerializeField] private InputActionAsset _InputActionsAsset;
    [SerializeField] private UnityEngine.InputSystem.UI.InputSystemUIInputModule _InputSystemUIInputModule;
    [SerializeField] private Camera _Camera;
    //Add functionality for presets as well

    public void ApplyToPlayerInput(PlayerInput playerInput)
    {
        playerInput.actions = _InputActionsAsset;
        playerInput.uiInputModule = _InputSystemUIInputModule;
        playerInput.camera = (_Camera != null) ? _Camera : Camera.main;
    }

    #endregion
}
