using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    ControlsActionMap movement;

    float moveSpeed = 10f;
    Vector3 forward, right;
    InputAction forwardAction;
    InputAction rightAction;

    void Start()
    {
        movement = new ControlsActionMap();
        movement.Enable();
        forwardAction = movement.PlayerMovement.Forward;
        rightAction = movement.PlayerMovement.Right;
        forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(forwardAction.ReadValue<float>(), 0, rightAction.ReadValue<float>());
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * rightAction.ReadValue<float>();
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * forwardAction.ReadValue<float>();

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = Vector3.Lerp(transform.forward, heading, 10 * Time.deltaTime);
        transform.position += rightMovement + upMovement;
    }
}
