using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerMovement player;
    static private GameManager instance;
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
        if(player.isDead)
            RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
