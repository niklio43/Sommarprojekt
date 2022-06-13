using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigid;
    float moveSpeed = 10f;
    Vector3 forward, right;
    InputAction rightAction;
    InputAction forwardAction;
    public static ControlsActionMap movement;

    private void Awake()
    {
        movement = new ControlsActionMap();
        movement.Enable();
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
        forwardAction = movement.PlayerMovement.Forward;
        rightAction = movement.PlayerMovement.Right;
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

    void FixedUpdate()
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
