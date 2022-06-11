using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Sword,
    Wand,
    Spear
}

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapon")]
public class WeaponObject : ItemData
{
    public WeaponType weaponType;

    public float strengthBonus, magicBonus;

    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
