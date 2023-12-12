// InventorySystem.cs
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance; // Singleton instance
    public Button activateButton;
    public GameObject inventoryPanel;
    public List<Item> inventoryItems = new List<Item>();
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

      private void Start()
    {
        // Attach the button click event
        activateButton.onClick.AddListener(ActivateInventory);
    }

    private void ActivateInventory()
    {
        // Show the inventory panel
        inventoryPanel.SetActive(true);
    }

    private void Awake()
    {
        Instance = this;
    }

    public void AddItemToInventory(Item newItem)
    {
        inventoryItems.Add(newItem);

        // Update the UI to display the new item
        UpdateInventoryUI();
    }

    internal void AddItemToInventory(string itemName)
    {
        throw new NotImplementedException();
    }

    public void RemoveItemFromInventory(Item item)
    {
        inventoryItems.Remove(item);

        // Update the UI to reflect the removal
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (i < inventoryItems.Count)
            {
                inventorySlots[i].AddItem(inventoryItems[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }
        }
    }
    
}
