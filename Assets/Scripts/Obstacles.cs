using System;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name + " is dead");
            player.isDead = true;
            GameManager.Instance.Die();
        }
    }
}
