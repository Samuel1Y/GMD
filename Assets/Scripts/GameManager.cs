using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SettingsData settingsData;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        LoadVolumeData();
    }

    // Update is called once per frame
    private void OnDisable()
    {
        SaveVolumeData();
    }

    private void SaveVolumeData()
    {
        PlayerPrefs.SetFloat("volume", settingsData.volume);
    }

    private void LoadVolumeData()
    {
        settingsData.volume = PlayerPrefs.GetFloat("volume", 100f);
    }
}
