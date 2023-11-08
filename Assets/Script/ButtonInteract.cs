using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public Button mainMenuButton;

    private void Start()
    {
        // Attach a method to be called when the button is clicked
        mainMenuButton.onClick.AddListener(OpenMainMenu);
    }

    private void Update()
    {
        // Check for interaction with the "interact" key (e.g., Spacebar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call the OpenMainMenu method when the key is pressed
            OpenMainMenu();
        }
    }

    void OpenMainMenu()
    {
        // Implement the code to open the main menu here
        // You can load a new scene, activate/deactivate UI elements, etc.
        Debug.Log("Main Menu Button Clicked!");
    }
}
