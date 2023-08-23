using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void TakeDamage(int damage)
    {
        // Player gets hurt
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0) 
        {

            healthBar.SetHealth(currentHealth);
            anim.SetTrigger("Hurt");

        }
        else
        {
            // Player Dead
            Debug.Log("Player is dead");
        }


    }
}
