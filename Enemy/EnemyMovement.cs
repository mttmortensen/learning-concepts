using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool moveToLeft = false;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        if (moveToLeft)
        {
            // Move left
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Move right
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        // Walking animation 
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsIdle", false);
    }
    public void SetDirection(bool toLeft)
    {
        moveToLeft = toLeft;
        if (moveToLeft)
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

