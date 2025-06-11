using UnityEngine;
/*
* Author: Xander 
* Date: 8/6/25
* Description: This script handles the functionality of the death brick in the conveyor belt area and
  the spinning fan level. When the player collides with this object, they take 100 dmg (max health) 
  triggers the respawn function in PlayerBehaviour.
*/
public class RespawnOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) // Check if the object that entered is the player
        {
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>(); // Try to get the PlayerBehaviour component from the colliding object

            if (player != null)
            {
                player.health -= 100; // Deal 100 damage, which is the maximum health and will trigger respawn 
                

            }
        }
    }
}
