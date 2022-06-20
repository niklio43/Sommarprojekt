using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Commands
{
    public InputAction iAction;
    public GameObject obj;

    public Commands(GameObject obj, InputAction iAction)
    {
        this.obj = obj;
        this.iAction = iAction;
    }
}
