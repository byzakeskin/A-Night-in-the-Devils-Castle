using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 1.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool _isRunning = false;
    private bool _isJumping = false;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        
        _isRunning = move != 0;
        animator.SetBool("_isRunning", _isRunning);

        
        if (move > 0)
            transform.localScale = new Vector3(2, 2, 2);
        else if (move < 0)
            transform.localScale = new Vector3(-2, 2, 2);

        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            _isJumping = true;
            animator.SetBool("_isJumping", _isJumping);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            _isJumping = false;
            animator.SetBool("_isJumping", _isJumping);
        }
    }
}


