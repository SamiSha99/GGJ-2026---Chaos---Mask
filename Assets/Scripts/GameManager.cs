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
        SoundsManager.Instance.PlayMusic(musicBackground);
        if(player == null)
            player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (player.isDead)
            RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddCoins()
    {
        coinsCollected++;
        text.SetText($"{coinsCollected}");
    }

    
    
}
