using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryEventTrigger : MonoBehaviour
{
    public GameObject scare;
    public Collider collision;
    public AudioSource scareSound;

    private void OnTriggerEnter(Collider other)
    {
        scare.SetActive(true);
        scareSound.Play();
        collision.enabled = false;
        
    }
}
