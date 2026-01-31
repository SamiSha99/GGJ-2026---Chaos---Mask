using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagFinish : MonoBehaviour
{
    public float delay = 0.2f;
    public AudioClip applauseSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finish!");
            SoundsManager.Instance.PlaySingle(applauseSound);
            StartCoroutine(FinishLevel());
        }
    }

    private IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
