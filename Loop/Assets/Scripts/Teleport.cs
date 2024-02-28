using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 teleportDestination = new Vector3(0.008923289f, 14.95068f, 81.9169f);
    public FPSController playerController;

    void Start()
    {
        playerController = gameObject.GetComponent<FPSController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Tele");
    }

    IEnumerator Tele()
    {
        //playerController.canMove = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = teleportDestination;
        yield return new WaitForSeconds(1f);
        //playerController.canMove = false;
    }
}
