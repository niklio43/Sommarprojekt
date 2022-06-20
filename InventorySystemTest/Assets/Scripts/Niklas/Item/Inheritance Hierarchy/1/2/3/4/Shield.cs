using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Object", menuName = "Inventory System/Items/OffHand/Shield")]
public class Shield : OffHand
{
    [SerializeField] Sprite icon;

    void Awake()
    {
        ItemName = "Shield";
        width = 2;
        height = 2;
        ItemIcon = icon;
    }
}
