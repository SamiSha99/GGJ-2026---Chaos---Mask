using UnityEngine;

public class Fall : MonoBehaviour
{
    private PlayerMovement player;
    public AudioClip fallSound;
    private bool falling;
    void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    
    void Update()
    {
        if (!falling && transform.position.y > player.transform.position.y)
        {
            falling = true;
            SoundsManager.Instance.PlaySingle(fallSound);
            StartCoroutine(GameManager.Instance.Die());
        }
    }
}
