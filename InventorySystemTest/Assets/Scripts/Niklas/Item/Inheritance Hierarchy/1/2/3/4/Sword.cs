using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Object", menuName = "Inventory System/Items/OneHanded/Sword")]
public class Sword : OneHanded
{
    [SerializeField] Sprite icon;

    void Awake()
    {
        ItemName = "Sword";
        width = 1;
        height = 2;
        ItemIcon = icon;
    }
}
