using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemGrid))]
public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject Player;
    InventoryController inventoryController;
    ItemGrid itemGrid;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        foreach (InventoryController i in Player.GetComponent<PlayerInventory>().inventory)
        {
            inventoryController = i;
        }

        itemGrid = GetComponent<ItemGrid>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryController.SelectedItemGrid = itemGrid;
        itemGrid.gameObject.transform.SetAsFirstSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryController.SelectedItemGrid = null;
    }
}
