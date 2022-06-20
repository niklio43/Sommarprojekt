using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Item itemData;

    public int HEIGHT
    {
        get
        {
            if (!rotated)
            {
                return itemData.height;
            }
            return itemData.width;
        }
    }

    public int WIDTH
    {
        get
        {
            if (!rotated)
            {
                return itemData.width;
            }
            return itemData.height;
        }
    }

    public int onGridPositionX, onGridPositionY;

    public bool rotated = false;

    internal void Set(Item itemData)
    {
        this.itemData = itemData;

        GetComponent<Image>().sprite = itemData.ItemIcon;

        Vector2 size = new Vector2();
        size.x = itemData.width * ItemGrid.tileSizeWidth;
        size.y = itemData.height * ItemGrid.tileSizeHeight;
        GetComponent<RectTransform>().sizeDelta = size;
    }

    internal void Rotate()
    {
        rotated = !rotated;

        RectTransform rectTransform = GetComponent<RectTransform>();

        rectTransform.rotation = Quaternion.Euler(0, 0, rotated ? 90f : 0f);
    }
}
