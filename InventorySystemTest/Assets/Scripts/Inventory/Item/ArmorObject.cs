using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorType
{
    Helmet,
    Chestplate,
    Leggings,
    Gloves
}

[CreateAssetMenu(fileName = "New Armor Object", menuName = "Inventory System/Items/Armor")]
public class ArmorObject : ItemData
{
    public ArmorType armorType;

    public float physicalDefenseBonus, magicDefenseBonus;

    public void Awake()
    {
        type = ItemType.Armor;
    }
}
