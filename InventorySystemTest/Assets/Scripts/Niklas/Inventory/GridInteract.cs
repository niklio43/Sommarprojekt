using System;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(ItemGrid))]
public class GridInteract : InputReciever
{
    GameObject Player;
    ItemGrid itemGrid;

    public override void Start()
    {
        base.Start();

        CreateCommand(gameObject, InputManager.Instance.mousePosition, MouseUpdate);

        Player = GameObject.FindGameObjectWithTag("Player");

        itemGrid = GetComponent<ItemGrid>();
    }

    void MouseUpdate(InputAction.CallbackContext ctx)
    {
        var playerInv = Player.GetComponent<PlayerInventory>();
        playerInv.mousePos = ctx.ReadValue<Vector2>();
        if (!itemGrid.inventoryBounds.Contains(playerInv.mousePos)) { return; }
        MouseEnter();
    }

    void MouseEnter()
    {
        foreach (InventoryController i in Player.GetComponent<PlayerInventory>().inventory)
        {
            i.SelectedItemGrid = itemGrid;
            itemGrid.gameObject.transform.SetAsFirstSibling();
        }
    }
}
