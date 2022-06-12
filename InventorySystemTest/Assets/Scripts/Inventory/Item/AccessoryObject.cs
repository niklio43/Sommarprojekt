using UnityEngine;

[CreateAssetMenu(fileName = "New Accessory Object", menuName = "Inventory System/Items/Accessory")]
public class AccessoryObject : ItemData
{
    public void Awake()
    {
        type = ItemType.Accessory;
    }
}
