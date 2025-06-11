using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Vector3 pushDirection = Vector3.left; // Set to left or right per belt
    public float speed = 3f;

    void OnTriggerStay(Collider other)  // When player is on the conveyor belt
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.Move(pushDirection.normalized * speed * Time.deltaTime); // Move the player in the direction of the conveyor belt
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
