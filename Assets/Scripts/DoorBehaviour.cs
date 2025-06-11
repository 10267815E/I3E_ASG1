using UnityEngine;
/*
* Author: Xander 
* Date: 10/6/25
* Description: This script handles the open and close behaviour of the doors. 
  It also handles the audio source when the door is opened and the unlock
  requirments for the door (3 collectibles collected). 
*/
public class DoorBehaviour : MonoBehaviour
{
    private bool isOpen = false; // Tracks whether the door is currently open
    private Vector3 closedRotation; // Rotation of door when closed
    private Vector3 openRotation; // Rotation of door when open

    public PlayerBehaviour player; // Reference to the player script

    AudioSource doorAudioSource; // Audio source component for playing door sound

    void Start()
    {
        // Get the AudioSource component attached to the door hinge obj in the scene
        doorAudioSource = GetComponent<AudioSource>();
        // Set the door's closed rotation to its current rotation
        closedRotation = transform.eulerAngles;
        // State the open rotation as 90 degrees around the Y axis from the closed position
        openRotation = closedRotation + new Vector3(0, 90f, 0); // Y axis rotation
    }

    public void Interact()
    {


        if (player.collectedCount >= 3) // Check if player has at least 3 collectibles
        {
            if (isOpen)
            {
                // Closes door
                transform.eulerAngles = closedRotation;
                isOpen = false;
            }
            else
            {
                // Plays door opening sound and opens the door
                doorAudioSource.Play();
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


