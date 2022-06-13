using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using WFC;
using WFC.Data;

[CustomEditor(typeof(DungeonGenerator))]
public class DungeonEditor : Editor
{
    DungeonGenerator m_Generator;
    int selectedIndex = 0;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        List<string> palettes = new List<string>();

        foreach (var palette in m_Generator.availablePalettes) {
            palettes.Add(palette.name);
        }

        selectedIndex = EditorGUILayout.Popup(selectedIndex, palettes.ToArray());
        m_Generator.selectedPalette = m_Generator.availablePalettes[selectedIndex];
    }


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
        m_Generator.availablePalettes = SavePaletteData.LoadPalettes();
    }
}
