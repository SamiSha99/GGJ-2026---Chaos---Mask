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
    public bool isDead = false;
    public bool isGrounded = false;
    
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
       moveHorizontal =  Input.GetAxis("Horizontal");
       if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
       {
           Debug.Log("Jump");
           SoundsManager.Instance.PlaySingle(jumpSound);
           rb.AddForce(Vector2.up * jumpForce);
           isGrounded = false;
       }
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
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


}
