using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Inventory System/Inventory")]
public class InventoryController : ScriptableObject
{
    [HideInInspector] public ItemGrid selectedItemGrid;

    public ItemGrid SelectedItemGrid
    {
        get => selectedItemGrid;
        set
        {
            selectedItemGrid = value;
            InventoryHighlight.MakeParent(value);
        }
    }

    InventoryItem selectedItem, overlapItem, itemToHighlight;
    RectTransform rectTransform;

    [Header("Inventory Settings")]
    [SerializeField] List<ItemData> items;
    [SerializeField] GameObject itemPrefab;
    [HideInInspector] public Transform canvasTransform;
    [HideInInspector] public ItemGrid mainInventory;
    [HideInInspector] public InventoryHighlight InventoryHighlight;

    Vector2 oldPosition;

    public void RotateItem()
    {
        if(selectedItem == null) { return; }

        selectedItem.Rotate();
    }

    //Make so item is dropped on ground first
    //Call when random item drop is wanted
    public void InsertRandomItem()
    {
        CreateRandomItem();
        InventoryItem itemToInsert = selectedItem;
        selectedItem = null;
        InsertItem(itemToInsert);
    }

    void InsertItem(InventoryItem itemToInsert)
    {
        if(mainInventory == null) { return; }

        itemToInsert.transform.localScale = canvasTransform.localScale;

        Vector2Int? posOnGrid = mainInventory.FindSpaceForObject(itemToInsert);

        if(posOnGrid == null) { return; }

        mainInventory.PlaceItem(itemToInsert, posOnGrid.Value.x, posOnGrid.Value.y);
    }

    public void HandleHighlight()
    {
        Vector2Int positionOnGrid = GetTileGridPosition();

        if(oldPosition == positionOnGrid) { return; }

        oldPosition = positionOnGrid;
        if (selectedItem == null)
        {
            itemToHighlight = selectedItemGrid.GetItem(positionOnGrid.x, positionOnGrid.y);

            if(itemToHighlight != null)
            {
                InventoryHighlight.Show(true);
                InventoryHighlight.SetSize(itemToHighlight);
                InventoryHighlight.SetPosition(selectedItemGrid, itemToHighlight);
            }
            else
            {
                InventoryHighlight.Show(false);
            }
        }
        else
        {
            InventoryHighlight.Show(selectedItemGrid.BoundryCheck(positionOnGrid.x, positionOnGrid.y, selectedItem.WIDTH, selectedItem.HEIGHT));
            InventoryHighlight.SetSize(selectedItem);
            InventoryHighlight.SetPosition(selectedItemGrid, selectedItem, positionOnGrid.x, positionOnGrid.y);
        }
    }

    void CreateRandomItem()
    {
        /*IN FUTURE
         * Change so random item is created from a specific pool of items recieved from the slain target enemy.
         * Check if there is enough grids for items to be created here.
         */
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem;
        rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasTransform);
        rectTransform.SetAsLastSibling();

        int selectedItemID = Random.Range(0, items.Count);

        inventoryItem.Set(items[selectedItemID]);
    }

    public void LeftMouseButtonPress()
    {
        Vector2Int tileGridPosition = GetTileGridPosition();
        if (selectedItem == null)
        {
            PickUpItem(tileGridPosition);
        }
        else
        {
            PlaceItem(tileGridPosition);
        }
    }

    Vector2Int GetTileGridPosition()
    {
        Vector2 position = Input.mousePosition;

        if (selectedItem != null)
        {
            position.x -= (selectedItem.WIDTH - 1) * (ItemGrid.tileSizeWidth) / 2;
            position.y += (selectedItem.HEIGHT - 1) * (ItemGrid.tileSizeHeight) / 2;
        }

        return selectedItemGrid.GetTileGridPosition(position);
    }

    void PlaceItem(Vector2Int tileGridPosition)
    {
        selectedItem.transform.localScale = canvasTransform.localScale;

        bool complete = selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y, ref overlapItem);
        if (complete)
        {
            selectedItem = null;
            if(overlapItem != null)
            {
                selectedItem = overlapItem;
                overlapItem = null;
                rectTransform = selectedItem.GetComponent<RectTransform>();
                rectTransform.SetAsLastSibling();
            }
        }
    }

    void PickUpItem(Vector2Int tileGridPosition)
    {
        selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
        if (selectedItem != null)
        {
            rectTransform = selectedItem.GetComponent<RectTransform>();
        }
    }

    public void ItemIconDrag()
    {
        if (selectedItem != null)
        {
            rectTransform.position = Input.mousePosition;
        }
    }
}