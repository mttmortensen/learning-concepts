using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed; // Speed of enemy 
    public float thresholdDistance = 10f; // Value of when the enemy will follow player

    public GameObject player; // ref to who the enemy is following

    private Animator anim;
    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        if (player != null)
        {
            float distanceToTarget = Vector2.Distance(transform.position, player.transform.position);



            if (distanceToTarget < thresholdDistance)
            {
                // Calculate the direction to move towards the player
                Vector2 direction = (player.transform.position - transform.position).normalized;

                // Move the enemy towards the player using Rigidbody2D
                rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
                               
                Debug.Log("Distance to player: " + Vector2.Distance(transform.position, player.transform.position));
                
                if (direction.x < 0)
                {

                    // Face left 
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    // Face right
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }

                // Walking animation 
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsIdle", false);
            }
            else
            {
                // Stop moving when player is out of range
                rb.velocity = new Vector2(0, rb.velocity.y);

                // Idle animation when not moving
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsIdle", true);
            }
        }
    }

    public void SetDirection(bool toLeft)
    {
        if (toLeft)
        {
            // Face left
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            // Face right
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}


