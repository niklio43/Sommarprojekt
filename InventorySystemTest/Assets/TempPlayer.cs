using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    bool openInv = false;

    [SerializeField] GameObject inventoryCanvas;

    void Start()
    {
        inventoryCanvas.GetComponent<CanvasGroup>().alpha = 0f;
        inventoryCanvas.GetComponent<CanvasGroup>().interactable = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            openInv = !openInv;
        }

        if (openInv)
        {
            inventoryCanvas.GetComponent<CanvasGroup>().alpha = 1f;
            inventoryCanvas.GetComponent<CanvasGroup>().interactable = true;
        }
        else
        {
            inventoryCanvas.GetComponent<CanvasGroup>().alpha = 0f;
            inventoryCanvas.GetComponent<CanvasGroup>().interactable = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * 2f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 2f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * 2f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 2f * Time.deltaTime;
        }
    }
}
