using UnityEngine;



public class RespawnOnTouch : MonoBehaviour
{
    public Transform spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
            if (controller != null && player != null)
            {
                player.health = 0; // Set player's health to 0
                // Disable the controller before changing position
                controller.enabled = false;
                other.transform.position = spawnpoint.position;
                controller.enabled = true;

            }
        }
    }
}
