using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InputReciever
{
    public ScriptableObject[] inventory;
    [SerializeField] Transform canvas;
    [SerializeField] ItemGrid mainInv;
    [SerializeField] InventoryHighlight invHighlight;

    public override void Start()
    {
        base.Start();
        foreach(InventoryController i in inventory)
        {
            CreateCommand(gameObject, InputManager.Instance.createRandomItem, i.InsertRandomItem);
            CreateCommand(gameObject, InputManager.Instance.clickInventory, i.LeftMouseButtonPress);
            CreateCommand(gameObject, InputManager.Instance.rotateItem, i.RotateItem);
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

            if (i.selectedItemGrid == null) { invHighlight.Show(false); return; }

            i.HandleHighlight();
        }
    }
}
