#region Copyright (c)
/****************************************
 * Copyright (c) All rights reserved to
 * !NullBool, NotNullBool
 * Contact info: notnullbool@gmail.com
 ****************************************/
#endregion

#region Imports
using UnityEngine.InputSystem.UI;
using NaughtyAttributes;
using static LanguageExt.Prelude;
using UnityEngine;
using UnityEngine.InputSystem;
#endregion

public class InputSettings : ScriptableObjectSingleton
{
    #region Variables
    [Required("Input Action Asset Required")]
    [SerializeField] private InputActionAsset _InputActionsAsset;
    [SerializeField] private InputSystemUIInputModule _UIInputModule;
    [SerializeField] private Camera _Camera;

    public void ApplyToPlayerInput(PlayerInput playerInput, InputActionAsset inputActions = null, InputSystemUIInputModule uIInputModule = null, Camera camera = null)
    {
        playerInput.actions = Optional(inputActions).
            IfNoneUnsafe(_InputActionsAsset);

        playerInput.uiInputModule = Optional(uIInputModule).
            IfNoneUnsafe(_UIInputModule);

        playerInput.camera = Optional(camera).IfNoneUnsafe(
            Optional(_Camera).
            IfNoneUnsafe(Camera.main));
    }

    #endregion
    static InputSettings()
    {
        
    }


}
