using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class PaletteData
{
    [HideInInspector] public string id;
    public string name;
    public Module[] modules;

    public PaletteData(int size, string name = "New Palette")
    {
        id = Guid.NewGuid().ToString();
        this.name = name;
        modules = new Module[size];
    }
}

[Serializable]
public class Module
{
    [HideInInspector] public static string mesh_path = "Assets/Assets/WFC/";
    
    public string mesh_name;
    //public int rotation;
    //Sockets
    public string posX, negX;
    public string posY, negY;
    // public string posZ, negZ;
    List<Module> valid_neighbours;

    public Module(string mesh_name, string posX, string negX, string posY, string negY)
    {
        this.mesh_name = mesh_name;
        this.posX = posX;
        this.negX = negX;
        this.posY = posY;
        this.negY = negY;
    }
}

public static class SavePaletteData
{
    public static string path = $"{Application.persistentDataPath}/WFC/Palettes/";

    private static void CheckFolders()
    {
        string subpath = $"{Application.persistentDataPath}/WFC";

        if (!Directory.Exists(subpath)) {
            Directory.CreateDirectory(subpath);
        }

        subpath = $"{Application.persistentDataPath}/WFC/Palettes";

        if (!Directory.Exists(subpath)) {
            Directory.CreateDirectory(subpath);
        }
    }

    public static void SaveToJSON(PaletteData palette)
    {
        CheckFolders();

        string data = JsonUtility.ToJson(palette, true);
        File.WriteAllText($"{path}{palette.id}.json", data);
    }

    public static List<PaletteData> LoadPalettes()
    {
        CheckFolders();

        string[] files = Directory.GetFiles(path);
        List<PaletteData> palettes = new List<PaletteData>();

        foreach (string file in files) {
            var data = File.ReadAllText(file);
            var palette = JsonUtility.FromJson<PaletteData>(data);
            palettes.Add(palette);
        }

        return palettes;
    }
}


//Serialized Objects


public class SerializedPaletteData : ScriptableObject
{
    public PaletteData data;
}

