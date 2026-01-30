using System;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private PlayerMovement player;
    public AudioClip deathSound;
    
    private void Start()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundsManager.Instance.PlaySingle(deathSound);
            Debug.Log(other.gameObject.name + " is dead");
            StartCoroutine(GameManager.Instance.Die());
        }
    }

    
}
