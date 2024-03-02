using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject pickUpText;
    public AudioSource pickUpSound;
    public bool interactable;

    void Start()
    {
        noteUI.SetActive(false);
        pickUpText.SetActive(false);

        interactable = false;

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            pickUpText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            pickUpText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            noteUI.SetActive(true);
            pickUpSound.Play();
            player.GetComponent<FPSController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void ExitButton()
    {
        noteUI.SetActive(false);
        player.GetComponent<FPSController>().enabled = true;
    }
}
