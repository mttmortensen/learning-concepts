using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Reference to the health fill image
    public Image healthFillImage;

    // Update the health bar UI based on the current health percentage
    public void UpdateHealthBar(float healthPercentage)
    {
        // Ensure the health percentage is between 0 and 1
        healthPercentage = Mathf.Clamp01(healthPercentage);

        // Update the fill amount of the health fill image
        healthFillImage.fillAmount = healthPercentage;
    }
}

