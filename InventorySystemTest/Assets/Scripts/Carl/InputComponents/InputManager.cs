using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private ControlsActionMap movement;
    InputAction rightAction;
    InputAction forwardAction;
    InputAction cameraToggle;
    public delegate void Inputs(InputAction.CallbackContext action);
    public static Inputs input;

    private void Awake()
    {
        movement = new ControlsActionMap();
        movement.Enable();
    }

    private void Start()
    {
        forwardAction = movement.PlayerMovement.Forward;
        rightAction = movement.PlayerMovement.Right;
        cameraToggle = movement.DebugControls.CameraToggle;

        forwardAction.started += InputSender;
        forwardAction.canceled += InputSender;
        rightAction.started += InputSender;
        rightAction.canceled += InputSender;
        cameraToggle.performed += InputSender;
    }

    private void InputSender(InputAction.CallbackContext ctx)
    {
        input(ctx);
    }
}
