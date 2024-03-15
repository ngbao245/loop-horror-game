using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScreen1 : MonoBehaviour
{
    private GameObject player;
    public GameObject startingScreen, hint;

    public float waitTime;


    void Start()
    {
        startingScreen.SetActive(true);
        player = GameObject.FindWithTag("Player");
        player.GetComponent<FPSController>().enabled = false;
        StartCoroutine(Starting());
    }

    IEnumerator Starting()
    {
        yield return new WaitForSeconds(waitTime);
        startingScreen.SetActive(false);
        player.GetComponent<FPSController>().enabled = true;
        hint.SetActive(true);
    }
}
