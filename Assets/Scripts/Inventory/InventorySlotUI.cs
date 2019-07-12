using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    private Item item;
    public Image itemIcon;

    public void AddItem(Item newItem)
    {
        item = newItem;
        itemIcon.gameObject.SetActive(true);
        itemIcon.sprite = item.inventorySprite;
    }

    public void ClearItem()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
        itemIcon.sprite = null;
    }
    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
        
        
    }
}
