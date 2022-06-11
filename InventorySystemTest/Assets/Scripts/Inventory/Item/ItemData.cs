using UnityEngine;


public enum ItemType
{
    Armor,
    Weapon,
    Accessory,
    Consumable,
    Default
}

public abstract class ItemData : ScriptableObject
{
    public int width = 1;
    public int height = 1;

    public ItemType type;

    public Sprite itemIcon;

    [TextArea(15, 20)]
    public string description;
}
