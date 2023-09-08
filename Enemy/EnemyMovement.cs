using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerToFollow; // Ref to player
    public float moveSpeed = 5f; // Enemy speed
    public float thresholdDistance = 5f; // Distance to start following

    private Rigidbody2D rb; // Enemy's Rigidbody

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody component
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerToFollow.position); // Calculate distance to player

        if (distanceToPlayer > thresholdDistance) // Check if within threshold
        {
            Vector2 direction = (playerToFollow.position - transform.position).normalized; // Get direction to player
            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y); // Set velocity towards player

            // Handle sprite direction
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Face right
            }
            else
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Face left
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Stop if player is far
        }
    }
}



