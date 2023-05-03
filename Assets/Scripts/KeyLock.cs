using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : MonoBehaviour
{
    public GameObject interactionText, keyHand;
    public AudioSource unlock;
    public bool interactable;
    [HideInInspector]
    public GameObject keyLock;

    void Start()
    {
        keyLock = this.gameObject;
    }

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
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && keyHand.active == true)
            {
                interactionText.SetActive(false);
                interactable = false;
                unlock.Play();
                keyLock.SetActive(false);
                keyHand.SetActive(false);
            }
        }
    }
}