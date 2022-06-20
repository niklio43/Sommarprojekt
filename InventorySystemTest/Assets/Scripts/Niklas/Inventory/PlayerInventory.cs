using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : InputReciever
{
    public ScriptableObject[] inventory;
    [SerializeField] Transform canvas;
    [SerializeField] ItemGrid mainInv;
    [SerializeField] InventoryHighlight invHighlight;
    Commands createRandomItem = new Commands("CreateRandomItem", 0);
    Commands inventoryToggle = new Commands("InventoryToggle", 0);
    Commands rotateItem = new Commands("RotateItem", 0);
    Commands clickInventory = new Commands("ClickInventory", 0);
    Commands mousePosition = new Commands("MousePosition", 0);

    void Awake()
    {
        commands.Add(createRandomItem);
        commands.Add(inventoryToggle);
        commands.Add(rotateItem);
        commands.Add(clickInventory);
        commands.Add(mousePosition);
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

            if(createRandomItem.value > 0)
                i.InsertRandomItem();

            if(clickInventory.value > 0)
                i.LeftMouseButtonPress();

            if(rotateItem.value > 0)
                i.RotateItem();

            if (i.selectedItemGrid == null) { invHighlight.Show(false); return; }

            i.HandleHighlight();
        }
    }
}
