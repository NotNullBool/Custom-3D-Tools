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
using UnityEngine.InputSystem.UI;
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
    [SerializeField] private InputSystemUIInputModule _InputSystemUIInputModule;
    [SerializeField] private Camera _Camera;


    //Add functionality for presets as well

    public void ApplyToPlayerInput(PlayerInput playerInput, InputActionAsset inputActions = null, InputSystemUIInputModule uIInputModule = null, Camera camera = null)
    {
        if (inputActions == null) inputActions = _InputActionsAsset;

        if (uIInputModule == null) uIInputModule = _InputSystemUIInputModule;

        if (camera == null) camera = (_Camera == null) ? Camera.main : _Camera;

        playerInput.actions = inputActions;
        playerInput.uiInputModule = uIInputModule;
        playerInput.camera = camera;
    }

    #endregion
    static InputSettings()
    {
        
    }


}

public class TestingSingleton : ScriptableObjectSingleton<TestingSingleton>
{
    static TestingSingleton()
    {
        //p_ResourceFolderLocation =
    }
}
