using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopManager : MonoBehaviour
{
    public string nextSceneName = "Scene2"; // Specify the next scene to load

    private bool isTransitioning = false;

    public GameObject fadeout;


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadeout()
    {
        fadeout.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(nextSceneName);
    }
}
