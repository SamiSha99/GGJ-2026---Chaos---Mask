using System;
using UnityEngine;

public class FlagFinish : MonoBehaviour
{
    private MainMenu mainMenu;

    private void Start()
    {
        mainMenu = FindAnyObjectByType<MainMenu>().GetComponent<MainMenu>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finish!");
            mainMenu.PlayGame();
        }
    }
}
