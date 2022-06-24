using System;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(ItemGrid))]
public class GridInteract : InputReciever
{
    GameObject Player;
    InventoryController inventoryController;
    ItemGrid itemGrid;

    public override void Start()
    {
        base.Start();

        CreateCommand(gameObject, InputManager.Instance.mousePosition, MouseUpdate);

        Player = GameObject.FindGameObjectWithTag("Player");

        foreach (InventoryController i in Player.GetComponent<PlayerInventory>().inventory)
        {
            inventoryController = i;
        }

        itemGrid = GetComponent<ItemGrid>();
    }

    void MouseUpdate(InputAction.CallbackContext ctx)
    {
        itemGrid.mousePosition = ctx.ReadValue<Vector2>();
        if (!GetComponent<ItemGrid>().inventoryBounds.Contains(itemGrid.mousePosition)) { MouseExit(); return; }
        MouseEnter();
    }

    void MouseEnter()
    {
        inventoryController.SelectedItemGrid = itemGrid;
        itemGrid.gameObject.transform.SetAsFirstSibling();
        Debug.Log("Enter");
    }

    void MouseExit()
    {
        inventoryController.SelectedItemGrid = null;
    }
}
