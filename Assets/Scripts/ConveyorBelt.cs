using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Vector3 pushDirection = Vector3.left; // Set to left or right per belt
    public float speed = 3f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.Move(pushDirection.normalized * speed * Time.deltaTime);
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
