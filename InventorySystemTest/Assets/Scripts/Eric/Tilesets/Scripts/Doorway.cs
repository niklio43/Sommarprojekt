using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{
    public bool isConnected { get { return (connectedRoom != null); } }

    public GameObject blocker;
    GameObject connectedRoom;


    public void RemoveDoorway()
    {
        Instantiate(blocker, transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }

}
