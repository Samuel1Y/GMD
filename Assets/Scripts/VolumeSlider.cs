using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text volumeText;

    void Start()
    {
        volumeText.text = Mathf.FloorToInt(volumeSlider.value * 100) + "%";
    }
    public void ChangeVolume()
    {
        //volumeText.text = volumeSlider.value.ToString("0.00");
        volumeText.text = Mathf.FloorToInt(volumeSlider.value * 100) + "%";
        AudioListener.volume = volumeSlider.value;
    }
}
