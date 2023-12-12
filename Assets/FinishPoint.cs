using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Check if the GameManager is present in the scene
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                // Check if the player has collected enough potions before proceeding
                if (gameManager.PotionsCollected >= gameManager.RequiredPotions)
                {
                    UnlockNewLevel();
        
                    // Proceed to the next level or load a specific level
                    if (goNextLevel)
                    {
                        SceneController.instance.NextLevel();
                    }
                    else
                    {
                        SceneController.instance.LoadScene(levelName);
                    }
                }
                else
                {
                    // Optionally display a message or perform other actions when the player has not collected enough potions
                    Debug.Log("Kamu harus mengumpulkan semua barangnya dulu!");
                }
            }
            else
            {
                // Optionally display a message or perform other actions when the GameManager is not found
                Debug.LogError("GameManager not found in the scene!");
            }
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}