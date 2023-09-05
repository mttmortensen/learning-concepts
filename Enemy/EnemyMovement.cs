using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the enemy moves towards the player
    public float detectionRange = 10f; // Range within which the enemy detects and follows the player

    private Transform player; // Reference to the player's transform
    private Rigidbody2D rb; // Reference to the enemy's Rigidbody2D

    private void Start()
    {
        // Find the player by tag (assuming your player has the tag "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If the player is within the detection range
        if (distanceToPlayer < detectionRange)
        {
            // Calculate the direction towards the player
            Vector2 moveDirection = (player.position - transform.position).normalized;

            // Move the enemy in that direction
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            // Stop moving if the player is out of detection range
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Flip the enemy sprite based on movement direction
        if (rb.velocity.x > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

