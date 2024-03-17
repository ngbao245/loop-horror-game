using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject fadeout;
    public GameObject text;

    public Material skybox;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Endgame());
    }

    IEnumerator Endgame()
    {
        RenderSettings.skybox = skybox;
        yield return new WaitForSeconds(5f);
        fadeout.SetActive(true);
        yield return new WaitForSeconds(3f);
        text.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }
}
