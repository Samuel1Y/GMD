using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightPickup : MonoBehaviour
{
    public GameObject interactionText, flashlight_world, flashlight_hand;
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
                flashlight_hand.SetActive(true);
                flashlight_world.SetActive(false);
            }
        }
    }
}

