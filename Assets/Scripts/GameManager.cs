using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerMovement player;
    static private GameManager instance;
    public AudioClip musicBackground;
    public TextMeshProUGUI text;
    
    
    private int coinsCollected = 0;
    
    public AudioClip deathSound;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return  instance;
        }
    }

    void Start()
    {
        if(player == null)
            player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }


    void Update()
    {
        /*if (player.isDead|| player)
            Die();*/
    }

    public void Die()
    {
        SoundsManager.Instance.PlaySingle(deathSound);
        Destroy(player.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddCoins()
    {
        coinsCollected++;
        text.SetText($"{coinsCollected}");
    }

    
    
}
