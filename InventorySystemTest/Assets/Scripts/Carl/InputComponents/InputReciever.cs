using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputReciever : MonoBehaviour
{
    public Dictionary<Commands, Action<InputAction.CallbackContext>> interactions = new Dictionary<Commands, Action<InputAction.CallbackContext>>();
    public Dictionary<string, Commands> recievers = new Dictionary<string, Commands>();
    public Commands newCom;

    public virtual void Start()
    {
        InputManager.input += ctx => InputHandler(ctx);
    }

    public virtual void InputHandler(InputAction.CallbackContext ctx)
    {
        if (!recievers.ContainsKey(ctx.action.name)) { return; }
        interactions[recievers[ctx.action.name]].Invoke(ctx);
    }

    public void CreateCommand(GameObject obj, InputAction input, Action<InputAction.CallbackContext> act)
    {
        newCom = new Commands(obj, input);
        interactions.Add(newCom, act);
        recievers.Add(input.name, newCom);
    }
}
