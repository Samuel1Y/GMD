using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text volumeText;
    public SettingsData settingsData;

    void Start()
    {
        volumeSlider.value = settingsData.volume;
        volumeText.text = Mathf.FloorToInt(volumeSlider.value * 100) + "%";
    }
    public void ChangeVolume()
    {
        volumeText.text = Mathf.FloorToInt(volumeSlider.value * 100) + "%";
        AudioListener.volume = volumeSlider.value;
        settingsData.volume = volumeSlider.value;
    }
}
