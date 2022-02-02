using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    [SerializeField] Slider difSlider;
    [SerializeField] float defaultdif = 0f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefControler.GetMasterVolume();
        difSlider.value = PlayerPrefControler.GetDifficuly();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player ... ");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefControler.SetMasterVolume(volumeSlider.value);
        PlayerPrefControler.SetDifficuly(difSlider.value);
        FindObjectOfType<LoadNextScene>().LoadMainMenur();
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        difSlider.value = defaultdif;
    }
}
