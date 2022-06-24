using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InputReciever
{
    public ScriptableObject[] inventory;
    [SerializeField] Transform canvas;
    [SerializeField] ItemGrid mainInv;
    [SerializeField] InventoryHighlight invHighlight;
    InventoryController inv;
    [HideInInspector] public Vector2 mousePos;

    public override void Start()
    {
        base.Start();
        foreach(InventoryController i in inventory)
        {
            inv = i;
            i.canvasTransform = canvas;
            i.mainInventory = mainInv;
            i.InventoryHighlight = invHighlight;
        }
        CreateCommand(gameObject, InputManager.Instance.createRandomItem, inv.InsertRandomItem);
        CreateCommand(gameObject, InputManager.Instance.clickInventory, inv.LeftMouseButtonPress);
        CreateCommand(gameObject, InputManager.Instance.rotateItem, inv.RotateItem);
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
