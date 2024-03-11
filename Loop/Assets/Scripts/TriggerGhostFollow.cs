using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGhostFollow : MonoBehaviour
{
    public GameObject ghost;
    private void OnTriggerEnter(Collider other)
    {
        if (ghost != null)
        {
            // Check if the GhostFollow component is present on the ghost GameObject
            GhostFollow ghostFollowScript = ghost.GetComponent<GhostFollow>();
            if (ghostFollowScript != null)
            {
                // Enable the GhostFollow script on the ghost GameObject
                ghostFollowScript.EnableGhostFollow();
            }
            else
            {
                Debug.LogError("GhostFollow script not found on the ghost GameObject.");
            }
        }
        else
        {
            Debug.LogError("Ghost GameObject is null.");
        }
    }
}
