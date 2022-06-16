using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace WFC.Data
{
    [Serializable]
    public class PaletteData
    {
        [HideInInspector] public string id;
        public string name;
        public ModuleData[] modules;

        public PaletteData(int size, string name = "New Palette")
        {
            id = Guid.NewGuid().ToString();
            this.name = name;
            modules = new ModuleData[size];
        }

        public Dictionary<string, Prototype> GetPrototypes()
        {
            Dictionary<string, Prototype> prototypes = new Dictionary<string, Prototype>();
            foreach (ModuleData module in modules) {
                prototypes.Add($"{module.id}_0", new Prototype(module.gameobject, $"{module.id}_0", 0, module.posX, module.negX, module.posZ, module.negZ));
                prototypes.Add($"{module.id}_1", new Prototype(module.gameobject, $"{module.id}_1", 1, module.negZ, module.posZ, module.posX, module.negX));
                prototypes.Add($"{module.id}_2", new Prototype(module.gameobject, $"{module.id}_2", 2, module.negX, module.posX, module.negZ, module.posZ));
                prototypes.Add($"{module.id}_3", new Prototype(module.gameobject, $"{module.id}_3", 3, module.posZ, module.negZ, module.negX, module.posX));
            }

            return prototypes;
        }
    }

    [Serializable]
    public class ModuleData
    {
        public string name;
        public GameObject gameobject;
        [HideInInspector] public string id;
        [HideInInspector] public string file_path;

        public string posX, negX;
        //public string posY, negY;
        public string posZ, negZ;

        public ModuleData(string file_path, string posX, string negX, string posZ, string negZ)
        {
            this.file_path = file_path;
            this.posX = posX;
            this.negX = negX;
            this.posZ = posZ;
            this.negZ = negZ;
        }

        public void UpdateData()
        {
            file_path = AssetDatabase.GetAssetPath(gameobject);
        }
    }

    [Serializable]
    public class Prototype
    {
        public readonly GameObject gameobject;
        public readonly string id;
        public readonly int rotation; 

        public readonly string posX, negX;
        //public readonly string posY, negY;
        public readonly string posZ, negZ;

        public List<string> valid_posX = new List<string>(), 
                            valid_negX = new List<string>(),
                            valid_posZ = new List<string>(), 
                            valid_negZ = new List<string>();

        public Prototype(GameObject gameobject, string id, int rotation, string posX, string negX, string posZ, string negZ)
        {
            this.gameobject = gameobject;
            this.id = id;
            this.rotation = rotation;
            this.posX = posX;
            this.negX = negX;
            this.posZ = posZ;
            this.negZ = negZ;
        }

        public Prototype()
        {
            this.gameobject = new GameObject();
            this.id = "empty";
            this.rotation = 0;
            this.posX = "empty";
            this.negX = "empty";
            this.posZ = "empty";
            this.negZ = "empty";
        }

        public List<string> validNeighbours(Vector2Int direction)
        {
            if(direction == Vector2Int.right) { return valid_posX; }
            else if(direction == Vector2Int.left) { return valid_negX; }
            else if(direction == Vector2Int.up) { return valid_posZ; }
            else return valid_negZ;
        }
    }


    //Serialized Objects


    public class SerializedPaletteData : ScriptableObject
    {
        public PaletteData data;
    }

}

