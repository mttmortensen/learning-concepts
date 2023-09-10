using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D attackCollider;
    [SerializeField] private float attackCooldown = 1f; // Duration of the attack cooldown

    private float lastAttackTime; // Time when the player last attacked

    void Update()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            if (Input.GetKeyDown("x"))
                Attack();   

        }
    }

    public void Attack()
    {
        // Set the last attack  time to the current time 
        lastAttackTime = Time.time;

        animator.SetTrigger("Attack");

    }

    public void EnableAttackCollider()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = true;
        }
    }

    public void DisableAttackCollider()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyDeath ed = collision.GetComponent<EnemyDeath>();

            if (ed != null)
            {
                ed.Death();
                EnemyManager.Instance.EnemyDefeated(); // Use the singleton instance to call the EnemyDefeated method
            }
        }
    }

}
