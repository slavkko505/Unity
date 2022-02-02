using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefControler : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULYTY_KEY = "difficulity";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
        
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficuly(float dif)
    {
        if(dif >= MIN_DIFFICULTY && dif <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULYTY_KEY,dif);
        }
        else
        {
            Debug.Log(" Dif set isnt in range");

        }
    }

    public static float GetDifficuly()
    {
        return  PlayerPrefs.GetFloat(DIFFICULYTY_KEY);  
    }
}
