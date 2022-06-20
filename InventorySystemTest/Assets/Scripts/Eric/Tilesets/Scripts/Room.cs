using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [HideInInspector] public List<Doorway> doorsways;

    private void Start()
    {
        doorsways = new List<Doorway>(transform.GetComponentsInChildren<Doorway>());
    }

}
