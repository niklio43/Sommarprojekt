using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumable")]
public class ConsumableObject : ItemData
{
    public int restoreHealthValue, restoreManaValue, increaseStrength;

    public void Awake()
    {
        type = ItemType.Consumable;
    }
}

