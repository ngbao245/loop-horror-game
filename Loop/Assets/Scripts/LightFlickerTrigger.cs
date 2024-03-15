using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightFlickerTrigger : MonoBehaviour
{
    public Light myLight;
    public Material offlight, onlight;
    public Renderer lightBulb;
    float defaultIntensity;

    float flickerTimer;
    float flickerDuration = 1.5f;
    float offDuration = 1.5f;
    bool isFlickering = false;
    System.Action flickerCompleteCallback;

    public GameObject ghost;
    public GameObject player;

    public MonoBehaviour playerFreeze;

    private Animator ghostAnimator;
    public float ghostMoveTowardsDuration;

    public AudioSource ghostAudioSource, heartBeatSound;
    public GameObject flashlight;
    public GameObject light;
    flashlight flash;

    public Renderer wall;
    public Material wallMaterial;

    public GameObject switchOff;
    ONOFFSwitch lightSwitchOff;

    void Start()
    {
        defaultIntensity = myLight.intensity;
        ghostAnimator = ghost.GetComponent<Animator>();
        ghostAudioSource = ghost.GetComponent<AudioSource>();
        flash = flashlight.GetComponent<flashlight>();
        lightSwitchOff = switchOff.GetComponent<ONOFFSwitch>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFlickering)
        {
            StartFlicker();
            flash.flashLightOFF.Play();
            light.SetActive(false);
        }
    }

    void StartFlicker()
    {
        isFlickering = true;
        flickerTimer = 0f;
    }

    void Update()
    {
        if (isFlickering)
        {
            if (lightSwitchOff.toggle == true)
            {
                lightSwitchOff.toggle = false;
            }


            // Freeze the character by disabling the movement script
            if (playerFreeze != null)
            {
                playerFreeze.enabled = false;
            }

            flickerTimer += Time.deltaTime;

            if (flickerTimer < flickerDuration)
            {
                // Flickering for the first 3 seconds with a more intense effect
                float flickerIntensity = Mathf.Lerp(0.4f, defaultIntensity, Mathf.PingPong(flickerTimer * 4.5f, 1f) / 1f);
                myLight.intensity = flickerIntensity;
            }
            else if (flickerTimer < flickerDuration + offDuration)
            {
                // Turning off for 1.5 seconds
                myLight.intensity = 0f;
                lightBulb.material = offlight;
            }
            else
            {
                // Turning on fully after 1.5 seconds
                myLight.intensity = defaultIntensity;
                lightBulb.material = onlight;

                // Activate the ghost
                ActivateGhost();

                // Flickering complete
                flickerTimer = 0f;
                isFlickering = false;

                // Notify the callback that flickering is complete
                if (flickerCompleteCallback != null)
                {
                    flickerCompleteCallback.Invoke();
                }
            }
        }
    }

    void ActivateGhost()
    {
        // Implement ghost appearance logic here
        ghost.SetActive(true);

        StartCoroutine(MoveTowardsPlayer());
    }

    IEnumerator MoveTowardsPlayer()
    {
        Vector3 initialPosition = ghost.transform.position;
        Vector3 targetPosition = new Vector3(player.transform.position.x, initialPosition.y, player.transform.position.z);
        Vector3 directionToPlayer = targetPosition - ghost.transform.position;

        //Initially facing the player
        Quaternion initialRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z), Vector3.up);
        ghost.transform.rotation = initialRotation;

        //Wait for seconds before running towards the player

        yield return new WaitForSeconds(0.5f);

        ghostAudioSource.Play();

        yield return new WaitForSeconds(0.5f);

        ghostAnimator.SetTrigger("Run");

        float startTime = Time.time;

        while (Time.time - startTime < ghostMoveTowardsDuration)
        {
            // Move towards the target position
            float journeyFraction = (Time.time - startTime) / ghostMoveTowardsDuration;
            ghost.transform.position = Vector3.Lerp(initialPosition, targetPosition, journeyFraction);

            // Rotate only around the Y-axis towards the player's position
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z), Vector3.up);
            ghost.transform.rotation = Quaternion.Slerp(ghost.transform.rotation, targetRotation, journeyFraction);


            yield return null;
        }

        // Ensure the ghost reaches the player's position and Y-rotation exactly
        ghost.transform.position = targetPosition;
        ghost.transform.LookAt(new Vector3(player.transform.position.x, ghost.transform.position.y, player.transform.position.z));

        // Turning off for 1.5 seconds
        myLight.intensity = 0f;
        lightBulb.material = offlight;

        yield return new WaitForSeconds(2f);

        Destroy(ghost);

        myLight.intensity = defaultIntensity;
        lightBulb.material = onlight;

        wall.material = wallMaterial;

        heartBeatSound.Play();

        if (playerFreeze != null)
        {
            playerFreeze.enabled = true;
        }
        if (light.active == false)
        {
            light.active = true;
        }
        Destroy(gameObject);
    }
}