using UnityEngine;
using Random = UnityEngine.Random;

public class LightFlicker : MonoBehaviour
{
    public GameObject intText, light;
    public bool toggle = true, interactable;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource lightSwitchSound;
    public Animator switchAnim;

    public Light myLight;
    float defaultIntensity;
    bool isOn;
    float timer;
    float delay;
    public float maxInterval = 1;
    public float maxFlicker = 0.2f;
    public float maxOffDelay = 2f;


    void Start()
    {
        defaultIntensity = myLight.intensity;
    }

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

            timer += Time.deltaTime;
            if (timer > delay)
            {
                ToggleLight();
            }
        }
    }

    void ToggleLight()
    {
        isOn = !isOn;

        if (isOn)
        {
            myLight.intensity = defaultIntensity;
            delay = Random.Range(0, maxInterval);
        }
        else
        {
            myLight.intensity = Random.Range(0f, defaultIntensity);
            delay = Random.Range(0, maxFlicker);

            delay += maxOffDelay;
        }

        timer = 0;
    }
}
