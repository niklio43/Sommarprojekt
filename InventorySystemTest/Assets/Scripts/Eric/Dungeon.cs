using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    [SerializeField] Tileset tileset;
    [SerializeField] int steps;

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        tileset.Init();
        int stepsTaken = 0;

        Room currentRoom = GenerateRoom(tileset.StartRoom, transform.position);

        while(stepsTaken < steps) {
            Doorway randomConnector = currentRoom.RandomDoor();

            Room chosenRoom = GenerateRoom(tileset.RandomRoom(), Vector3.zero);
            Doorway randomDoor = chosenRoom.RandomDoor();

            Debug.Log(randomDoor.transform.eulerAngles.y);
            Debug.Log(randomConnector.transform.eulerAngles.y);

            float newRot = 180 - (randomDoor.transform.eulerAngles.y - randomConnector.transform.eulerAngles.y);
            chosenRoom.transform.eulerAngles = new Vector3(0, newRot, 0);

            chosenRoom.transform.position += randomConnector.transform.position - randomDoor.transform.position + (randomConnector.transform.forward * -1);

            randomDoor.connectedDoor = randomConnector;
            randomConnector.connectedDoor = randomDoor;

            randomDoor.GetComponent<MeshRenderer>().material.color = Color.red;
            randomConnector.GetComponent<MeshRenderer>().material.color = Color.red;

            currentRoom = chosenRoom;
            stepsTaken++;
        }

    }

    Room GenerateRoom(Room room, Vector3 position)
    {
        var newRoom = Instantiate(room, position, Quaternion.identity, transform);

        return newRoom;
    }

}
