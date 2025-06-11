using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private bool isOpen = false;
    private Vector3 closedRotation;
    private Vector3 openRotation;

    public PlayerBehaviour player; // Reference to the player script

    void Start()
    {
        closedRotation = transform.eulerAngles;
        openRotation = closedRotation + new Vector3(0, 90f, 0); // Y axis rotation
    }

    public void Interact()
    {


        if (player.collectedCount >= 3) // Check if player has at least 3 collectibles
        {
            if (isOpen)
            {
                transform.eulerAngles = closedRotation;
                isOpen = false;
            }
            else
            {
                transform.eulerAngles = openRotation;
                isOpen = true;
                Debug.Log("Door opened!");
            }
        }
        else
        {
            Debug.Log("Collect at least 3 energy sources to unlock this door!");
        }
    }

    public void ResetDoor() // Closes the door

    {
        transform.eulerAngles = closedRotation;
        isOpen = false;

    }

}


