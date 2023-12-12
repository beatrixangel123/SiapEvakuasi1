using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPotion : MonoBehaviour
{
    public GameManager GM;
    private void OnTriggerEnter2D(Collider2D TheThingThatWalkedIntoMe)
    {
        if(TheThingThatWalkedIntoMe.name == "Player")
        {
            Debug.Log("Kamu dapat barangnya!");
            GM.CollectPotion();
            Destroy(gameObject);
        }
    }
}
