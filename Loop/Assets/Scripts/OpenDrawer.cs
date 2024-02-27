using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    public GameObject intText;
    public bool interactable, toggle;
    public AudioSource drawerSound;
    public Animator drawerAnimator;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleDrawer();
            }
        }
    }

    void ToggleDrawer()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                drawerSound.Play();
                if (toggle)
                {
                    drawerAnimator.ResetTrigger("close");
                    drawerAnimator.SetTrigger("open");
                }
                else
                {
                    drawerAnimator.ResetTrigger("open");
                    drawerAnimator.SetTrigger("close");
                }
                intText.SetActive(false);
                interactable = false;
            }
        }
    }
}
