using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapon")]
public class WeaponObject : ItemData
{
    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
