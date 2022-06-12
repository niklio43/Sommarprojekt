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
    public GameObject mesh;
    [HideInInspector] public string mesh_name;

    public string posX, negX;
    //public string posY, negY;
    public string posZ, negZ;
    [HideInInspector] public Prototype[] prototypes;

    public Module(string mesh_name, string posX, string negX, string posZ, string negZ)
    {
        this.mesh_name = mesh_name;
        this.posX = posX;
        this.negX = negX;
        this.posZ = posZ;
        this.negZ = negZ;
    }

    public void UpdateData()
    {
        mesh_name = AssetDatabase.GetAssetPath(mesh);
        CreatePrototypes();
    }

    void CreatePrototypes()
    {
        prototypes = new Prototype[4];

        prototypes[0] = new Prototype(0, posX, negX, posZ, negZ);
        prototypes[1] = new Prototype(1, negZ, posZ, posX, negX);
        prototypes[2] = new Prototype(2, negX, posX, negZ, posZ);
        prototypes[3] = new Prototype(3, posZ, negZ, negX, posX);
    }
}

[Serializable]
public class Prototype
{
    public int rotation;

    public string posX, negX;
    //public string posY, negY;
    public string posZ, negZ;

    public Prototype(int rotationIndex, string posX, string negX, string posZ, string negZ)
    {
        rotation = rotationIndex;
        this.posX = posX;
        this.negX = negX;
        this.posZ = posZ;
        this.negZ = negZ;
    }
}

//Serialized Objects


public class SerializedPaletteData : ScriptableObject
{
    public PaletteData data;
}



