using UnityEngine;
/*
* Author: Xander 
* Date: 8/6/25
* Description: This script handles the behavior of collectible items in the game, by toggling their active state when a player collects the item.
*/
public class CollectibleBehaviour : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Collect(PlayerBehaviour player)
    {
        // Disable the collectible object
        gameObject.SetActive(false);
    }

    public void Respawn() // Call respawn function
    {
        gameObject.SetActive(true);  // Re-enable the collectible object after respawn
    }
}