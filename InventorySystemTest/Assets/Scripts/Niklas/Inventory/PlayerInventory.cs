using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InputReciever
{
    public ScriptableObject[] inventory;
    [SerializeField] Transform canvas;
    [SerializeField] ItemGrid mainInv;
    [SerializeField] InventoryHighlight invHighlight;

    void Awake()
    {
        foreach (InventoryController i in inventory)
        {
            i.canvasTransform = canvas;
            i.mainInventory = mainInv;
            i.InventoryHighlight = invHighlight;
        }
    }

    void Update()
    {
        foreach (InventoryController i in inventory)
        {
            i.ItemIconDrag();

            if(Input.GetKeyDown(KeyCode.W))
                i.InsertRandomItem();

            if(Input.GetKeyDown(KeyCode.Mouse0))
                i.LeftMouseButtonPress();

            if(Input.GetKeyDown(KeyCode.R))
                i.RotateItem();

            if (i.selectedItemGrid == null) { invHighlight.Show(false); return; }

            i.HandleHighlight();
        }
    }
}
