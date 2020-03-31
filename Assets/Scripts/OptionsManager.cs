using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider musicSlider;
    public Slider soundSlider;
   
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ChangeMusicVolume(float volume)
    {
        Globals.musicVolume = volume;
    }

    public void ChangeSoundsVolume(float volume)
    {
        Globals.soundVolume = volume;
    }

    private void Start()
    {
        musicSlider.value = Globals.musicVolume;
        soundSlider.value = Globals.soundVolume;
    }
    private void Update()
    {
        if (musicSlider.value != Globals.musicVolume)
        {
            Globals.musicVolume = musicSlider.value;
        }
        if (soundSlider.value != Globals.soundVolume)
        {
            Globals.soundVolume = soundSlider.value;
        }
    }
}
