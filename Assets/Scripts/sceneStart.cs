using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneStart : MonoBehaviour
{
    public GameObject cutsceneCam, player;
    public float cutsceneTime;
    public AudioSource startSound;

    void Start()
    {
        startSound.Play();
    }
    //delete if not used
    IEnumerator cutscene()
    {
        yield return new WaitForSeconds(cutsceneTime);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
    }
}