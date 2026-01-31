using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerMovement player;

    private bool follow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!follow) return;
        float directionx = player.transform.position.x - transform.position.x;
        float directiony = player.transform.position.y - transform.position.y + 1.75f;
        Vector3 direction = new Vector3(directionx, directiony, 1);
        transform.position += direction * (player.moveSpeed * 5 * Time.deltaTime);


    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            follorPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            follorPlayer();
        }
    }

    void follorPlayer()
    {
        follow = true;
        player.key = transform;
    }
}
