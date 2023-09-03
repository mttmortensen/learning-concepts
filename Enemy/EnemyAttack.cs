using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool isPlayerInRange = false;

    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private float checkRate = 0.2f; // Check every 0.2 seconds
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private Collider2D attackCollider;

    private float nextCheck;

    private void Start()
    {
        attackCollider.enabled = false;
    }

    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            CheckForPlayer();
        }
    }
    public void EnableAttackCollider()
    {
        attackCollider.enabled = true;
    }

    public void DisableAttackCollider()
    {
        attackCollider.enabled = false;
    }

    void CheckForPlayer()
    {
        Vector2 direction = Vector2.right * transform.localScale.x;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, attackRange, playerLayer);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }

        anim.SetBool("IsAttacking", isPlayerInRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null )
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }
}

