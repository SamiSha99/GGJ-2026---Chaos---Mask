using System;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed;
    public float chaseRange;
    private PlayerMovement player;
    private Animator anim;
    private float moveHorizontal;
    private SpriteRenderer spriteRenderer;
    
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim  = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        rb.freezeRotation = true;
        
        if (distance <= chaseRange)
        {
            float flag ;
            anim.SetBool("EnemyWalk", true);
            Vector3 direction = player.transform.position - transform.position;
            
            if (direction != Vector3.zero)
                spriteRenderer.flipX = direction.x > 0;
            
            
            direction.y = 0;
            direction.Normalize();
            
            transform.position += direction * speed * Time.deltaTime; 
        }
        else
        {
            anim.SetBool("EnemyWalk", false);
        }
    }
}