using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : InputReciever
{
    Rigidbody rigid;
    CharacterController controller;
    float moveSpeed = 10f;
    Vector3 forward, right;
    Commands forwardComs = new Commands("Forward", 0);
    Commands rightComs = new Commands("Right", 0);

    private void Awake()
    {
        commands.Add(forwardComs);
        commands.Add(rightComs);
        commands.Add(new Commands("Right", 0));
        controller = gameObject?.GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
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
        Move(rightComs.value, forwardComs.value);
    }

    public void Move(float rightAction, float forwardAction)
    {
        Vector3 direction = new Vector3(forwardAction, 0, rightAction);
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * rightAction;
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * forwardAction;

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = Vector3.Lerp(transform.forward, heading, 10 * Time.deltaTime);
        transform.position += rightMovement + upMovement;
    }
}
