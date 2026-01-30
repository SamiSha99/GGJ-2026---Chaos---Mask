using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float climbSpeed = 4f;

    Rigidbody2D rb;
    bool onLadder;

    float originalGravity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
    }

    void Update()
    {
        if (!onLadder) return;

        float v = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, v * climbSpeed);
        
        rb.gravityScale = v != 0 ? 0f : originalGravity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            onLadder = true;
            rb.gravityScale = 0f;
            rb.linearVelocity = Vector2.zero;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            onLadder = false;
            rb.gravityScale = originalGravity;
        }
    }
}
