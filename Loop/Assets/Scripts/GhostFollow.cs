using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostFollow : MonoBehaviour
{
    public NavMeshAgent ghost;
    public Transform player;
    public Animator ghostAnimator;

    public float jumpScareDistance = 2.0f;
    public GameObject jumpCam;
    public GameObject offFlashlight;
    public AudioSource audioJumpscare;

    public MonoBehaviour playerFreeze;


    public void EnableGhostFollow()
    {
        enabled = true;
    }

    private void Start()
    {
        ghostAnimator = GetComponent<Animator>();
        audioJumpscare = jumpCam.GetComponent<AudioSource>();
    }

    void Update()
    {
        ghost.SetDestination(player.position);

        if (ghost.hasPath && ghost.remainingDistance > ghost.stoppingDistance)
        {
            ghostAnimator.SetTrigger("Run");

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < jumpScareDistance)
            {
                TriggerJumpScare();
            }
        }
        else
        {
            ghostAnimator.ResetTrigger("Run");
        }
    }

    void TriggerJumpScare()
    {
        jumpCam.SetActive(true);
        audioJumpscare.Play();
        offFlashlight.SetActive(false);
        playerFreeze.enabled = false;
        Destroy(gameObject);
    }
}
