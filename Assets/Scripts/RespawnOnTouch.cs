using UnityEngine;



public class RespawnOnTouch : MonoBehaviour
{
    public Transform spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                // Disable the controller before changing position
                controller.enabled = false;
                other.transform.position = spawnpoint.position;
                controller.enabled = true;
            }
        }
    }
}
