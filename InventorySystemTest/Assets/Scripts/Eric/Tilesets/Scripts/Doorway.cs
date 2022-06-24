using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{
    public bool CannotBeBlocked = false;
    public bool isConnected { get { return (connectedDoor != null); } }

    public GameObject blocker;
    public Doorway connectedDoor;


    public void RemoveDoorway()
    {
        Instantiate(blocker, transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }

}
