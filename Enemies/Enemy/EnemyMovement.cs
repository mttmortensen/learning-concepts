using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerToFollow; // Ref to player
    public LayerMask enemyLayerMask; // Layermask for enemies to help detect them
    public float moveSpeed = 5f; // Enemy speed
    public float thresholdDistance = 5f; // Distance to start following
    public float stoppingDistance = 1; // Distance to slow down / stop when an enemy is in front

    private Rigidbody2D rb; // Enemy's Rigidbody
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody component
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleAnimations();
        FollowPlayer();

    }

    void FollowPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerToFollow.position); // Calculate distance to player

        if (distanceToPlayer > thresholdDistance && !CheckEnemyAhead()) // Check if within threshold and no enemy ahead
        {
            Vector2 direction = (playerToFollow.position - transform.position).normalized; // Get direction to player
            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y); // Set velocity towards player

/*            Debug.Log("Following Player. Distance: " + distanceToPlayer + " Direction: " + direction);
*/
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

    bool CheckEnemyAhead()
    {
        // Use OverlapCircle to check for enemies in a specified radius in front of the current enemy
        Vector2 checkPosition = (Vector2)transform.position + (Vector2)(playerToFollow.position - transform.position).normalized * stoppingDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkPosition, stoppingDistance, enemyLayerMask);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject) // Ensure we're not detecting ourselves
            {
                return true;
            }
        }
        return false;
    }

    void HandleAnimations()
    {
        // If the enemy is moving, set the "IsWalking" parameter to true
        if (rb.velocity.x != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

}



