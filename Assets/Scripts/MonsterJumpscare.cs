using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterJumpscare : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public float jumpscareTime;
    public AudioSource jumpscareSound;
    public string sceneName;
    private MonsterController monsterController;

    void Start()
    {
        monsterController = this.gameObject.GetComponent<MonsterController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && monsterController.isChasing == true)
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