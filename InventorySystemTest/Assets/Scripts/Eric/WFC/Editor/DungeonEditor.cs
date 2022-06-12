using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using WFC;

[CustomEditor(typeof(DungeonGenerator))]
public class DungeonEditor : Editor
{
    DungeonGenerator m_Generator;

    public void OnSceneGUI()
    {
        Handles.color = Color.red;

        Vector3 pos = m_Generator.transform.position;
        int sizeX = m_Generator.sizeX;
        int sizeY = m_Generator.sizeY;

        Handles.DrawLine(new Vector3(pos.x - (sizeX / 2), pos.y, pos.z + (sizeY / 2)), new Vector3(pos.x + (sizeX / 2), pos.y, pos.z + (sizeY / 2)));
        Handles.DrawLine(new Vector3(pos.x - (sizeX / 2), pos.y, pos.z - (sizeY / 2)), new Vector3(pos.x - (sizeX / 2), pos.y, pos.z + (sizeY / 2)));
        Handles.DrawLine(new Vector3(pos.x - (sizeX / 2), pos.y, pos.z - (sizeY / 2)), new Vector3(pos.x + (sizeX / 2), pos.y, pos.z - (sizeY / 2)));
        Handles.DrawLine(new Vector3(pos.x + (sizeX / 2), pos.y, pos.z - (sizeY / 2)), new Vector3(pos.x + (sizeX / 2), pos.y, pos.z + (sizeY / 2)));
    }

    void OnEnable()
    {
        m_Generator = (DungeonGenerator)target;
    }
}
