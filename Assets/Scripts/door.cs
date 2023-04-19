using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door : MonoBehaviour
{
    public GameObject interactionText, dialogue;
    public GameObject? lock1, lock2, lock3, lock4, lock5;
    public bool interactable, toggle, locked;
    public Animator doorAnim;
    public AudioSource openDoor, closeDoor;

    public string dialogueString;
    public Text dialogueText;
    public float dialogueTime;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactionText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactionText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (!lock1.active && !lock2.active && !lock3.active && !lock4.active && !lock5.active) locked = false;
        
            if (interactable == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (locked == true)
                    {
                        dialogueText.text = dialogueString;
                        dialogue.SetActive(true);
                        interactionText.SetActive(false);
                        StartCoroutine(disableDialogue());
                    }
                    else
                    {
                        toggle = !toggle;
                        if (toggle == true)
                        {
                            doorAnim.ResetTrigger("close");
                            doorAnim.SetTrigger("open");
                            openDoor.Play();
                        }
                        if (toggle == false)
                        {
                            doorAnim.ResetTrigger("open");
                            doorAnim.SetTrigger("close");
                            closeDoor.Play();
                        }
                        interactionText.SetActive(false);
                        interactable = false;
                    }
                }
            }
    }
    IEnumerator disableDialogue()
    {
        yield return new WaitForSeconds(dialogueTime);
        dialogue.SetActive(false);
    }
}
