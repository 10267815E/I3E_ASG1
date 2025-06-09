using UnityEngine;

public class ToxicZone : MonoBehaviour
{
    public int damagePerSecond = 10; // Damage per second
    private float damageCooldown = 1f; // One second between damage ticks
    private float timer = 0f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= damageCooldown)
            {
                PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
                if (player != null)
                {
                    player.health -= damagePerSecond;
                    Debug.Log("Toxic damage! Health: " + player.health);
                }

                timer = 0f; // Reset timer
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0f; // Reset timer when player leaves
        }
    }
}


