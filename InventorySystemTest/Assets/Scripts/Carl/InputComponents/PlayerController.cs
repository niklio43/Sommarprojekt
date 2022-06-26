using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : InputReciever
{
    Rigidbody rigid;
    CharacterController controller;
    float moveSpeed = 50f;
    Vector3 forward, right;
    Vector3 rightMovement, upMovement;

    private void Awake()
    {
        controller = gameObject?.GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        CreateCommand(this.gameObject, InputManager.Instance.forwardAction, ForwardMove);
        CreateCommand(this.gameObject, InputManager.Instance.rightAction, RightMove);
    }

    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, 2);
        if(transform.position.y - hit.point.y < 1 || transform.position.y - hit.point.y > 1)
        {
            Vector3 groundPos = new Vector3(transform.position.x, hit.point.y + 1, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, groundPos, (10 / (transform.position.y - groundPos.y)) * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        DoMove();
    }

    public void ForwardMove(InputAction.CallbackContext ctx)
    {
        upMovement = forward * moveSpeed * Time.deltaTime * ctx.ReadValue<float>();
    }

    public void RightMove(InputAction.CallbackContext ctx)
    {
        rightMovement = right * moveSpeed * Time.deltaTime * ctx.ReadValue<float>();
    }

    public void DoMove()
    {
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = Vector3.Lerp(transform.forward, heading, 10 * Time.fixedDeltaTime);
        transform.position += rightMovement + upMovement;
    }
}
