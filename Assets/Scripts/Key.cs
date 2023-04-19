using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject interactionText, key_hand;
    public AudioSource pickup;
    public bool interactable;
    [HideInInspector]
    public GameObject key_world;

    void Start()
    {
        key_world = this.gameObject;
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
            if (Input.GetKeyDown(KeyCode.E) && !key_hand.active)
            {
                interactionText.SetActive(false);
                interactable = false;
                pickup.Play();
                key_hand.SetActive(true);
                key_world.SetActive(false);
            }
        }
    }
}