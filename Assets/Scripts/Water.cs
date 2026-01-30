using System;
using UnityEngine;

public class Water : MonoBehaviour
{
    public AudioClip waterSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundsManager.Instance.PlaySingle(waterSound);
            Debug.Log("fall in water");
            StartCoroutine(GameManager.Instance.Die());
        }
    }
    
}
