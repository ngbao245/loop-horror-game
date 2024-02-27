using UnityEngine;

public class LookAndInteract : MonoBehaviour
{
    public GameObject drawer; // Reference to the drawer GameObject
    public GameObject intText; // Reference to the interaction text
    public AudioSource openSound; // Sound played when opening the drawer
    public AudioSource closeSound; // Sound played when closing the drawer

    private bool isOpen = false; // Flag to track if the drawer is open or closed

    void Update()
    {
        // Check if the player is looking at the drawer and presses the "E" key
        if (Input.GetKeyDown(KeyCode.E) && IsLookingAtDrawer())
        {
            if (isOpen)
            {
                CloseDrawer();
            }
            else
            {
                OpenDrawer();
            }
        }
    }

    // Function to check if the player is looking at the drawer
    bool IsLookingAtDrawer()
    {
        // Raycast from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        // If the ray hits the drawer collider and it is tagged as "Drawer", return true
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == drawer && drawer.CompareTag("Drawer"))
        {
            return true;
        }

        return false;
    }

    // Function to open the drawer
    void OpenDrawer()
    {
        // Play open sound
        openSound.Play();

        // Perform any animation or interaction logic here

        // Set isOpen flag to true
        isOpen = true;

        // Display interaction text
        intText.SetActive(false);
    }

    // Function to close the drawer
    void CloseDrawer()
    {
        // Play close sound
        closeSound.Play();

        // Perform any animation or interaction logic here

        // Set isOpen flag to false
        isOpen = false;

        // Hide interaction text
        intText.SetActive(false);
    }
}
