using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject light, hintKey, hintTurnOnFL;
    public bool toggle;
    public AudioSource flashLightOFF, flashLightON;
    private int count = 0;

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
            if (count <= 0)
            {
                hintTurnOnFL.SetActive(false);
                hintKey.SetActive(true);
                count++;
            }
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
