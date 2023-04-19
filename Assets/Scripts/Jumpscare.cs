using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public float jumpscareTime;
    public AudioSource jumpscareSound;
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            anim.SetTrigger("Jumpscare");
            StartCoroutine(jumpscare());
            jumpscareSound.Play();
        }
    }
    IEnumerator jumpscare()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(sceneName);
    }
}