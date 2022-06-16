using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputReciever : MonoBehaviour
{
    public List<Commands> commands = new List<Commands>();
    public virtual void Start()
    {
        InputManager.input += InputHandler;
    }

    public virtual void InputHandler(InputAction.CallbackContext action)
    {
        foreach(Commands command in commands)
        {
            if(action.action.name == command.name)
            {
                command.value = action.ReadValue<float>();
            }
        }
    }
}
