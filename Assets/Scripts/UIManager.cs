using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI collectibleText;
    public PlayerBehaviour player;

    void Update()
    {
        if (player != null)
        {
            healthText.text = "Health: " + player.health;
            collectibleText.text = "Collectibles: " + player.collectedCount + " / " + player.totalCollectibles;
        }
    }
}
