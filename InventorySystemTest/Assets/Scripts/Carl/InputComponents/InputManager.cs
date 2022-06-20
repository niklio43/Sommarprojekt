using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    ControlsActionMap movement;
    public InputAction rightAction;
    public InputAction forwardAction;
    public InputAction cameraToggle;
    public delegate void Inputs(InputAction action);
    public static Inputs input;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        movement = new ControlsActionMap();
        movement.Enable();
        forwardAction = movement.PlayerMovement.Forward;
    }

    private void Start()
    {
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
       input(forwardAction);
    }
}
