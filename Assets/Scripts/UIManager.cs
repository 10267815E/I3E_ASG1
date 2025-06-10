using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI collectibleText;
    public PlayerBehaviour player;

    public GameObject popupScreenUI;
    private bool popupActive = true;

    public GameObject victoryPanelUI; // UI for victory screen

    void Start()
    {
        popupScreenUI.SetActive(true); // Show splash screen at start
        Time.timeScale = 0f; // Pause game
    }

    void Update()
    {
        if (popupActive && Input.anyKeyDown)
        {
            popupScreenUI.SetActive(false); // Hide popup screen
            Time.timeScale = 1f; // Resume game
            popupActive = false;
        }

        if (!popupActive && player != null)
        {
            healthText.text = "Health: " + player.health;
            collectibleText.text = "Collectibles: " + player.collectedCount + " / " + player.totalCollectibles;
        }
    }

    public void ShowVictoryPanel()

    {
        victoryPanelUI.SetActive(true); // Show victory panel when player collects all collectibles by setting panel as active

    }

}

