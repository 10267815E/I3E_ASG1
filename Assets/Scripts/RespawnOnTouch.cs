using UnityEngine;

public class RespawnOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();

            if (player != null)
            {
                player.health -= 100; // Deal 100 damage

            }
        }
    }
}
