using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    private int currentHealth;

    // Ref to HealthBar 
    public HealthBar healthBar;

    public Animator anim;

    private void Start()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(currentHealth);
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        // Player gets hurt
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0) 
        {

            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
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
