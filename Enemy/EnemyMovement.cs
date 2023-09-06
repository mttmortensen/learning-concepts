using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the enemy moves

    private Rigidbody2D rb; // Reference to the enemy's Rigidbody2D

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Check the spawn point's name to determine the movement direction
        if (transform.parent.name == "Spawn Left")
        {
            MoveRight();
        }
        else if (transform.parent.name == "Spawn Right")
        {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        transform.localScale = new Vector3(1, 1, 1); // Face right
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        transform.localScale = new Vector3(-1, 1, 1); // Face left
    }
}


