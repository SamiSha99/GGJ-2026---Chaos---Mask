using System;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float  jumpForce = 10f;
    private float moveHorizontal;
    private bool isJumping = false;
    public bool isDead = false;
    public AudioClip landingSound;
    
    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
       moveHorizontal =  Input.GetAxis("Horizontal");
       if (Input.GetKeyDown(KeyCode.Space)&& !isJumping)
       {
           rb.AddForce(Vector2.up * jumpForce);
           isJumping = true;
       }
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveHorizontal * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //SoundsManager.Instance.PlaySingle(landingSound);
        isJumping = false;
        if (other.gameObject.CompareTag("Obstacle"))
        {
            isDead = true;
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("Ground"))
        {
            SoundsManager.Instance.PlaySingle(landingSound);
        }
    }
    
    
}
