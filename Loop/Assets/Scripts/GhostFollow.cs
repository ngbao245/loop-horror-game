using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostFollow : MonoBehaviour
{
    public NavMeshAgent ghost;
    public Transform player;
    public Animator ghostAnimator;


    public void EnableGhostFollow()
    {
        enabled = true;
    }

    private void Start()
    {
        ghostAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        ghost.SetDestination(player.position);

        if (ghost.hasPath && ghost.remainingDistance > ghost.stoppingDistance)
        {
            ghostAnimator.SetTrigger("Run");
        }
        else
        {
            ghostAnimator.ResetTrigger("Run");
        }
    }
}
