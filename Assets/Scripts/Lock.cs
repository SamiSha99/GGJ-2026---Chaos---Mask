using UnityEngine;

public class Lock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
