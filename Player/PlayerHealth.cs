using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    // Ref to HealthBar 
    public HealthBar healthBar;

    [SerializeField] private Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(1);
        
        if (anim == null)
            anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        // Player gets hurt
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        // Update health bar
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBar.UpdateHealthBar(healthPercentage);

        if (currentHealth > 0) 
        {

            anim.SetTrigger("Hurt");
        }
        else
        {
            anim.SetTrigger("Death");
            HandlePlayerDeath();
        }


    }

    private void HandlePlayerDeath()
    {
        GetComponent<PlayerMovement>().enabled = false;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
