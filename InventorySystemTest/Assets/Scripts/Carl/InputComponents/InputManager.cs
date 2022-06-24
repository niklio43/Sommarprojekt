using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    ControlsActionMap controls;
    public InputAction rightAction, forwardAction, cameraToggle, createRandomItem, toggleInventory, rotateItem, clickInventory, mousePosition;
    public delegate void Inputs(InputAction.CallbackContext ctx);
    public static Inputs input;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        controls = new ControlsActionMap();
        controls.Enable();
        forwardAction = controls.PlayerMovement.Forward;
        BindInputs();
    }

    void BindInputs()
    {
        rightAction = controls.PlayerMovement.Right;
        cameraToggle = controls.DebugControls.CameraToggle;
        createRandomItem = controls.DebugControls.CreateRandomItem;
        toggleInventory = controls.Inventory.ToggleInventory;
        rotateItem = controls.Inventory.RotateItem;
        clickInventory = controls.Inventory.ClickInventory;
        mousePosition = controls.Inventory.MousePosition;

        forwardAction.started += InputSender;
        forwardAction.canceled += InputSender;
        rightAction.started += InputSender;
        rightAction.canceled += InputSender;
        mousePosition.performed += InputSender;
        cameraToggle.performed += InputSender;
        createRandomItem.performed += InputSender;
        rotateItem.performed += InputSender;
        clickInventory.performed += InputSender;
    }

    void InputSender(InputAction.CallbackContext ctx)
    {
       input(ctx);
    }
}
