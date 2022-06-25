using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Object", menuName = "Inventory System/Items/OneHanded/Sword")]
public class Sword : OneHanded
{
    [SerializeField] Sprite icon;
    [SerializeField] List<string> possiblePrefixes;
    [SerializeField] List<string> possibleSuffixes;

    void Awake()
    {
        ItemName = "Sword";
        width = 1;
        height = 2;
        ItemIcon = icon;
        Prefix = possiblePrefixes[Random.Range(0, possiblePrefixes.Count)];
        Suffix = possibleSuffixes[Random.Range(0, possibleSuffixes.Count)];
    }
}
