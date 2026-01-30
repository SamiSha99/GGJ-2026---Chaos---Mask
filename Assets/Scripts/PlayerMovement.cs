using System;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private float moveHorizontal;
    private bool isJumping = false;
    public bool isDead = false;
    bool wasGrounded = false;
    bool isGrounded = false;

    public AudioClip landingSound;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public TextMeshProUGUI  text;
    
    
   

    public AudioClip jumpSound;
    public AudioClip deathSound;
    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            SoundsManager.Instance.PlaySingle(jumpSound);
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
        if (isGrounded && wasGrounded == false)
        {
            SoundsManager.Instance.PlaySingle(landingSound);
        }
        wasGrounded = isGrounded;
        moveHorizontal = Input.GetAxis("Horizontal");
        // if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        // {
        //     rb.AddForce(Vector2.up * jumpForce);
        //     isJumping = true;
        // }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveHorizontal * moveSpeed, rb.linearVelocity.y);
        Vector2 v = rb.linearVelocity;
        if (v.x != 0)
        {
            spriteRenderer.flipX = v.x > 0;
            animator.SetBool("walk", Math.Abs(rb.linearVelocity.x) > 0);
        }
        else
            animator.SetBool("walk", false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
        if (other.gameObject.CompareTag("Obstacle"))
        {
            isDead = true;
            SoundsManager.Instance.PlaySingle(deathSound);
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("Ground"))
        {
            SoundsManager.Instance.PlaySingle(landingSound);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
           
            GameManager.Instance.AddCoins();
            Destroy(other.gameObject);
        }
    }


}
