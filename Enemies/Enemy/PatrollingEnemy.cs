using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public float speed = 2f;
    private int direction = 1; // 1 for right, -1 for left
    public float rayLength = 0.5f; // Length of the raycast
    public float waitTime = 1f; // Time to wait at the edge

    private bool isWaiting = false; // To check if the enemy is in waiting state

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isWaiting)
        {
            // Move enemy
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

            // Set the walking animation
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);

            // Edge Detection via rayCast creation
            Vector2 rayStart = (direction == 1) ? transform.position + Vector3.right * 0.5f : transform.position + Vector3.left * 0.5f; // Adjusted ray start
            RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, rayLength);

            if (hit.collider == null)
                StartCoroutine(WaitAtEdge());
        }
        else
        {
            // Set the idle animation
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsIdle", true);
        }
    }


    IEnumerator WaitAtEdge()
    {
        isWaiting = true;
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsIdle", true);
        yield return new WaitForSeconds(waitTime);
        direction *= -1; // Change direction
        FlipSprite();
        isWaiting = false;
    }


    void FlipSprite()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}