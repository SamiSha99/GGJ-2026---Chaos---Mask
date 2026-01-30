using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerMovement player;
    static private GameManager instance;
    public TextMeshProUGUI text;
    public float deathDelay = 2f;
    
    
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
        if(player == null)
            player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }
    

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(deathDelay);
        Destroy(player.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddCoins()
    {
        coinsCollected++;
        text.SetText($"{coinsCollected}");
    }

    
    
}
