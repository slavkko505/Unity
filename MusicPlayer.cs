using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
   
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefControler.GetMasterVolume();
    }
    public void SetVolume(float volemu)
    {
        audioSource.volume = volemu;
    }
}
