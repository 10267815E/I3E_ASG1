using UnityEngine;
using TMPro;
/*
* Author: Xander 
* Date: 10/6/25
* Description: This script handles the UI of the game, including the popup screen at the start,
  health display, collectible count, and the victory panel when all collectibles are collected.
*/
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText; // UI element for displaying player's health
    public TextMeshProUGUI collectibleText; // UI element for displaying collectible count
    public PlayerBehaviour player; // Reference to the player script to access health and collectibles variables

    public GameObject popupScreenUI; // Reference to the popup screen shown at the start
    private bool popupActive = true; // Tracker for popup screen state

    public GameObject victoryPanelUI; // UI for victory screen

    void Start()
    {
        popupScreenUI.SetActive(true); // Show splash screen at start
        Time.timeScale = 0f; // Pause game while popup is active
    }

    void Update()
    {
        if (popupActive && Input.anyKeyDown)
        {
            popupScreenUI.SetActive(false); // Hide popup screen
            Time.timeScale = 1f; // Resume game
            popupActive = false; // Set popup state to inactive so it isnt shown again
        }

        // Update the health and collectible counters once the game is active
        if (!popupActive && player != null)
        {
            healthText.text = "Health: " + player.health; // Updates health
            collectibleText.text = "Collectibles: " + player.collectedCount + " / " + player.totalCollectibles; // Updates collectible count
        }
    }
    
    
    public void ShowVictoryPanel()

    {
        victoryPanelUI.SetActive(true); // Show victory panel when player collects all collectibles by setting panel as active

    }

}

