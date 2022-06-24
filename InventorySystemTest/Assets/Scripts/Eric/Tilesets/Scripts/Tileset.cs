using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tileset", menuName = "Dungeon/Tileset")]
public class Tileset : ScriptableObject
{
    public new string name;
    [Header("Start Room")]
    public Room StartRoom;
    [Header("End Room")]
    public Room EndRoom;

    [Space]
    public List<Room> tiles;

    public void Init()
    {
        foreach (Room room in tiles) {
            room.Init();
        }
    }

    public Room RandomRoom()
    {
        return tiles[Random.Range(0, tiles.Count)];
    }

}
