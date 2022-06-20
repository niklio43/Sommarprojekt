using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tileset", menuName = "Dungeon/Tileset")]
public class Tileset : ScriptableObject
{
    public string name;

    public List<Room> tiles;
}
