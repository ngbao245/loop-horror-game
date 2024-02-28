using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject light;
    public bool toggle;
    public AudioSource flashLightOFF, flashLightON;

    void Start()
    {
        if (toggle == false)
        {
            light.SetActive(false);
        }
        if (toggle == true)
        {
            light.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggle = !toggle;
            if (toggle == false)
            {
                flashLightOFF.Play();
                light.SetActive(false);
            }
            if (toggle == true)
            {
                flashLightON.Play();
                light.SetActive(true);
            }
        }
    }
}
