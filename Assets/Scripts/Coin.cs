using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundsManager.Instance.PlaySingle(coinSound);
            GameManager.Instance.AddCoins();
            Destroy(gameObject);
        }
    }
}
