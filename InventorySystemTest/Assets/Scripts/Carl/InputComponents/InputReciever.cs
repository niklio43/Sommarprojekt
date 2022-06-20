using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputReciever : MonoBehaviour
{
    public Dictionary<Commands, Action> interactions = new Dictionary<Commands, Action>();
    public Dictionary<InputAction, Commands> recievers = new Dictionary<InputAction, Commands>();
    public Commands newCom;

    public virtual void Start()
    {
        InputManager.input += InputHandler;
        CreateCommand(this.gameObject, InputManager.Instance.forwardAction, CoolTest);

    }

    public virtual void InputHandler(InputAction action)
    {
        interactions[recievers[action]].Invoke();
    }

    public void CreateCommand(GameObject obj, InputAction input, Action act)
    {
        newCom = new Commands(obj, input);
        interactions.Add(newCom, act);
        recievers.Add(input, newCom);
    }

    public void CoolTest()
    {
        Debug.Log("Funkar");
    }
}
