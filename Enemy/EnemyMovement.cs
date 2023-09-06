using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;

    private Rigidbody2D Rb
    {
        get
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
            }
            return rb;
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveRight()
    {
        transform.localScale = new Vector3(1, 1, 1); // Face right
        transform.Translate(Vector2.right * transform.localScale.x * moveSpeed * Time.deltaTime); // Move enemy
    }

    public void MoveLeft()
    {
        transform.localScale = new Vector3(-1, 1, 1); // Face left
        transform.Translate(Vector2.left * transform.localScale.x * moveSpeed * Time.deltaTime); // Move enemy
    }
}
