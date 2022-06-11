using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AccessoryType
{
    Ring,
    Necklece,
    Totem
}

[CreateAssetMenu(fileName = "New Accessory Object", menuName = "Inventory System/Items/Accessory")]
public class AccessoryObject : ItemData
{
    public AccessoryType accessoryType;

    public float physicalDefenseBonus, magicDefenseBonus, strengthBonus, magicBonus;

    public void Awake()
    {
        type = ItemType.Accessory;
    }
}
