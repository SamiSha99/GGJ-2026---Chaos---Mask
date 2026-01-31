using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerMovement player;

    private bool follow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionx = player.transform.position.x - transform.position.x;
        float directiony = player.transform.position.y - transform.position.y;

        
        if (follow)
        {
            
           //transform.position += Vector3.MoveTowards(transform.position,player.transform.position,0)
            Vector3 direction = new Vector3(directionx, directiony, 1);
            transform.position +=  direction * (player.moveSpeed*player.moveSpeed*5 * Time.deltaTime); 

        }
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            follow = true;
            collision.gameObject.GetComponent<PlayerMovement>().key = transform;
        }
        else follow = false;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            follow = false;
        }
        else follow = true;
    }
}
