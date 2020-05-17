using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class Settings : MonoBehaviour
{   

    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown rslDropdown;
    public Dropdown gfxDropdown;
    public Dropdown langDropdown;
    public Slider volumeSlider;
    public Toggle isFSc;
    public AudioMixer am;

    private float volume = -4;
    private int quality = 0;
    private int resolution = 0;
    private bool isFullScreen = true;
    private int lang = 0;


    private void Start() {
        Load();
    }

    public void setLang(int lang){
        this.lang = lang;
    }

    public void Save() {
        string key = "Settings";
        
        SaveData data = new SaveData();

        data.volume = this.volume;
        data.quality = this.quality;
        data.resolution = this.resolution;
        data.isFullScreen = this.isFullScreen;
        data.lang = this.lang;

        string value = JsonUtility.ToJson(data);
        
        PlayerPrefs.SetString(key, value);
        
        PlayerPrefs.Save();
    }

    private void Load() {
        string key = "Settings";
        if (PlayerPrefs.HasKey(key)) {
            string value = PlayerPrefs.GetString(key);
            
            SaveData data = JsonUtility.FromJson<SaveData>(value);
            
            this.volume = data.volume;
            AudioVolume(this.volume);
            volumeSlider.value = data.volume;

            this.quality = data.quality;
            Quality(this.quality);            
            gfxDropdown.value = this.quality;


            this.resolution = data.resolution;
            Resolution(this.resolution);
            rslDropdown.value = this.resolution;

            this.lang = data.lang;
            langDropdown.value = this.lang;

            this.isFullScreen = data.isFullScreen;
            isFSc.isOn = data.isFullScreen;
        }
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
        this.volume = sliderValue;
    }


    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }


    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
        this.quality = q;
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
        rslDropdown.ClearOptions();
        rslDropdown.AddOptions(resolutions);
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
        this.resolution = r;
    }

    
}


public class SaveData {
    public float volume;
    public int quality;
    public int resolution;
    public bool isFullScreen;
    public int lang;
}
