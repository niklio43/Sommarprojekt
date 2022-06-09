using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
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
    public Mesh mesh;
    [HideInInspector] public string mesh_name;
    //public int rotation;

    public string posX, negX;
    public string posY, negY;
    // public string posZ, negZ;

    public Module(string mesh_name, string posX, string negX, string posY, string negY)
    {
        this.mesh_name = mesh_name;
        this.posX = posX;
        this.negX = negX;
        this.posY = posY;
        this.negY = negY;
    }

    public void UpdateData()
    {
        mesh_name = AssetDatabase.GetAssetPath(mesh);
    }
}

//Serialized Objects


public class SerializedPaletteData : ScriptableObject
{
    public PaletteData data;
}



