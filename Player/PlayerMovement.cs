using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;   
    private Animator animator;

    // Ground check variables
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the player object
        rb = GetComponent<Rigidbody2D>();

        // Get the Animator component attached to the player object
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //This code snippet is responsible for handling the player's horizontal movement, jumping behavior, and animations.
        HandleMovement();
        HandleJumping();
        HandleAnimations();

    }    

    private void FixedUpdate()
    {

        // Check if the player is falling
        if (rb.velocity.y < 0)
        {
            // Increase gravity scale when falling
            rb.gravityScale = 1.5f;
        }
        else
        {
            // Reset gravity scale when not falling
            rb.gravityScale = 1f;
        }
    }

    void HandleMovement()
    {
        // Get the horizontal input from the player (left or right arrow keys, A or D keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Create a new velocity vector, using the horizontal input multiplied by speed for the x component,
        // and keeping the current y component (vertical velocity) from the Rigidbody
        Vector2 velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Assign the new velocity to the Rigidbody, effectively moving the player horizontally
        rb.velocity = velocity;

        // Check if the character is moving left or right
        if (horizontalInput > 0)
        {
            // Moving right, ensure the character is facing right
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < 0)
        {
            // Moving left, flip the character to face left
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

    }

    void HandleJumping()
    {
        // Check if the Jump button is pressed (usually the space bar) and if the player is not already jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply an upward force to the Rigidbody, causing the player to jump
            // The ForceMode2D.Impulse applies the force instantly, giving a jump effect
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
    }

    void HandleAnimations()
    {

        // Idle and Running
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        // Jumping
        if (rb.velocity.y > 0.1f && !isGrounded)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        // Falling
        if (rb.velocity.y < 0.5f && !isGrounded)
            animator.SetBool("Falling", true);
        else
            animator.SetBool("Falling", false);
        
    }

}
