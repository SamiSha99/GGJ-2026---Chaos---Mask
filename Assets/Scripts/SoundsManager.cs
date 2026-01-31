using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class SoundsManager : MonoBehaviour
{
    
    
    public static SoundsManager Instance;
    public AudioClip musicBackground;
    public AudioSource soundSFX;
    public AudioSource musicSFX;
    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        if(musicSFX == null)
            return;
    }
    private void Start()
    {
        PlayMusic(musicBackground);
        
    }

    public void PlaySingle(AudioClip clip)
    {
        soundSFX.clip = clip;
        soundSFX.PlayOneShot(soundSFX.clip);
    }
    
    public void PlayMusic(AudioClip clip)
    {
        musicSFX.clip = clip; ;
        musicSFX.Play();
    }
}
