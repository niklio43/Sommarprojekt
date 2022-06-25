using UnityEngine;

public abstract class Item : ScriptableObject
{
    public int width = 1;
    public int height = 1;

    Sprite itemicon;

    public Sprite ItemIcon
    {
        get { return itemicon; }
        set { itemicon = value; }
    }

    string prefix, suffix, itemname;

    public string Prefix
    {
        get { return prefix; }
        set { prefix = value; }
    }

    public string Suffix
    {
        get { return suffix; }
        set { suffix = value; }
    }

    public string ItemName
    {
        get { return itemname; }
        set { itemname = value; }
    }
}
