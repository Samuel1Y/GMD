using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightPickup : MonoBehaviour
{
    public GameObject interactionText, flashlight_table, flashlight_hand;
    public AudioSource pickup;
    public bool interactable;

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
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionText.SetActive(false);
                interactable = false;
                //pickup.Play(); // to play sound
                flashlight_hand.SetActive(true);
                flashlight_table.SetActive(false);
            }
        }
    }
}

