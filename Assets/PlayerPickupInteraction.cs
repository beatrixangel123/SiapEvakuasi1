// Example: PlayerPickupInteraction.cs
using UnityEngine;

public class PlayerPickupInteraction : MonoBehaviour
{
    public Item itemToPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventorySystem.Instance.AddItemToInventory(itemToPickup);
            Destroy(gameObject);
        }
    }
}
