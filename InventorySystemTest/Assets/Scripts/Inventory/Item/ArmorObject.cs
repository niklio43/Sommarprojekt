using UnityEngine;

[CreateAssetMenu(fileName = "New Armor Object", menuName = "Inventory System/Items/Armor")]
public class ArmorObject : ItemData
{
    public void Awake()
    {
        type = ItemType.Armor;
    }
}
