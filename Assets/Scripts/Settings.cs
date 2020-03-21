using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Settings : MonoBehaviour
{    
    //public AudioMixer am;
    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;
    bool isFullScreen = true;


    // public void AudioVolume(float sliderValue)
    // {
    //     am.SetFloat("masterVolume", sliderValue);
    // }


    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }


    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    public void Awake()
    {
        resolutions = new List<string>();
        //dropdown.AddOptions("Resolution");
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width +"x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }
}

