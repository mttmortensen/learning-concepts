using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Variable to keep track of the number of collected items
    private int silverGemsCount = 0;
    public int totalSilverGems;

    [SerializeField] private Text silverGemsText;
    [SerializeField] private DoorController doorController;

    // This method is called when the player's collider enters another collider marked as a trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object the player collided with has the tag "Silver gems"
        if (other.CompareTag("Silver Gems"))
        {
            // Increment the count of collected silver gems
            silverGemsCount++;

            // Log the current count to the console (for debugging purposes)
            silverGemsText.text = silverGemsCount.ToString();

            // Destroy the collected gem so it disappears from the scene
            Destroy(other.gameObject);

            // Check if all the silver gems have been collected for the level
            if (silverGemsCount >= totalSilverGems)
            {
                doorController.OpenDoor();
            }
        }

        
    }
}
