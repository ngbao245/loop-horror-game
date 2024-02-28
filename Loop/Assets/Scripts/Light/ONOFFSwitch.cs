using Unity.VisualScripting;
using UnityEngine;

public class ONOFFSwitch : MonoBehaviour
{
    public GameObject intText, light;
    public bool toggle = true, interactable;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource sound;
    public Animator switchAnim;

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
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                sound.Play();
                if (toggle == true)
                {
                    switchAnim.ResetTrigger("off");
                    switchAnim.SetTrigger("on");
                }
                if (toggle == false)
                {
                    switchAnim.ResetTrigger("on");
                    switchAnim.SetTrigger("off");
                }
                intText.SetActive(false);
                interactable = false;
            }
        }
        if (toggle == false)
        {
            light.SetActive(false);
            lightBulb.material = offlight;
        }
        if (toggle == true)
        {
            light.SetActive(true);
            lightBulb.material = onlight;
        }
    }
}
