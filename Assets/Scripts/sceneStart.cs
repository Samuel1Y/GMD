using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneStart : MonoBehaviour
{
    public AudioSource startSound;

    void Start()
    {
        startSound.Play();
    }
}