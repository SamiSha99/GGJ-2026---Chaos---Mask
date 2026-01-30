using System;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance;
    
    public AudioSource soundSFX;
    public AudioSource musicSFX;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        soundSFX.clip = clip;
        soundSFX.Play();
    }
    
    public void PlayMusic(AudioClip clip)
    {
        musicSFX.clip = clip;
        musicSFX.Play();
    }
    
    
    
}
