using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PotionsCollected = 0;
    public int RequiredPotions = 3; // Set the required number of potions to proceed to the next level

    public Text PotionsOutput;

    void Update()
    {
        PotionsOutput.text = "Barang yang terkumpul:" + PotionsCollected;

        // Check if the player has collected enough potions to proceed to the next level
        if (PotionsCollected >= RequiredPotions)
        {
            // You might want to display a message or perform other actions here
            Debug.Log("Kamu bisa lanjut ke ruangan selanjutnya!");
        }
    }

    public void CollectPotion()
    {
        PotionsCollected++;
    }

    public void UsePotion()
    {
        // Check to make sure the player has potions to use
        if (PotionsCollected > 0)
        {
            PotionsCollected--;
        }
        else
        {
            // Optionally display a message or perform other actions when attempting to use a potion with none collected
            Debug.Log("Barang tidak bisa digunakan!");
        }
    }
}
