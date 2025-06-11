using UnityEngine;
/*
* Author: Xander 
* Date: 9/6/25
* Description: This script handles the damage over time mechanic in the toxic spill section.
*/
public class ToxicZone : MonoBehaviour
{
    public int damagePerSecond = 10; // Damage per second
    private float damageCooldown = 0.3f; // 0.3s between damage ticks
    private float timer = 0f; // Tracks elapsed time since last damage tick

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // Checks if obj in the zone is player
        {
            timer += Time.deltaTime; // Increment timer

            if (timer >= damageCooldown) // If enough time has passed, do dmg to player
            {
                PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
                if (player != null)
                {
                    player.health -= damagePerSecond; // Deal damage to player
                    Debug.Log("Toxic damage! Health: " + player.health);
                }

                timer = 0f; // Reset timer
            }
        }
    }

    void OnTriggerExit(Collider other) // When player leaves the toxic zone
    {
        if (other.CompareTag("Player"))
        {
            timer = 0f; // Reset timer when player leaves to avoid instant dmg when player re-enters
        }
    }
}


