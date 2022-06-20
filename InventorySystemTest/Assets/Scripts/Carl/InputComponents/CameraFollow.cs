using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public static bool following;

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float camSize = 10f;

    private Camera cam;
    private Vector3 newPos;
    private Vector3 startPos;
    private bool posReached;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        startPos = transform.position;
    }

    void Update()
    {
        if (following)
        {
            if (!posReached)
            {
                newPos = target.transform.position + offset;
                transform.localPosition = Vector3.Lerp(transform.position, newPos, 10 * Time.deltaTime);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camSize, 10 * Time.deltaTime);
                if(Mathf.Approximately(transform.localPosition.magnitude, newPos.magnitude))
                    posReached = true;
            }
            else
            {
                newPos = target.transform.position + offset;
                transform.localPosition = newPos;
            }
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.position, startPos, 10 * Time.deltaTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 20f, 10 * Time.deltaTime);
            posReached = false;
        }
    }
}
