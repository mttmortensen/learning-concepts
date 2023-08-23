using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Variable to keep track of the number of collected items
    private int silverGemsCount = 0;

    [SerializeField] private Text silverGemsText;

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
        }

        // You can add more conditions here for other types of collectible items
    }
}
