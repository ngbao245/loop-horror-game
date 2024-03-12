using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopJumpScare : MonoBehaviour
{
    public GameObject fadeOut;
    public float waitToFade = 3f;
    public string loopBackScene = "Scene4";

    private void Start()
    {
        StartCoroutine(LoopBack());
    }
    
    IEnumerator LoopBack()
    {
        yield return new WaitForSeconds(waitToFade);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(loopBackScene);
    }
}
