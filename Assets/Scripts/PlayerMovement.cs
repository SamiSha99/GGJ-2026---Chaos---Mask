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
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private GroundCheck groundCheck;
    [HideInInspector]
    public Transform key;
    public AudioClip jumpSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        if (groundCheck.IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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

    private void Jump()
    {
        SoundsManager.Instance.PlaySingle(jumpSound);
        rb.AddForce(Vector2.up * jumpForce);
    }

}
