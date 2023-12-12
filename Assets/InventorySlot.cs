// InventorySlot.cs
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.itemImage;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void RemoveItem()
    {
        // Handle item removal logic here
        // Example: Call a method in your inventory system to remove the item
        InventorySystem.Instance.RemoveItemFromInventory(item);
    }
}

