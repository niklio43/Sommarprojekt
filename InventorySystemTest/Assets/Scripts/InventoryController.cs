using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector] public ItemGrid selectedItemGrid;

    void Update()
    {
        if(selectedItemGrid == null) { return; }

        if(Input.GetMouseButtonDown(0))
            Debug.Log(selectedItemGrid.GetTileGrídPosition(Input.mousePosition));
    }
}
