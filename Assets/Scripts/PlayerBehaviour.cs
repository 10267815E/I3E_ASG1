using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.ProBuilder.Shapes;
/*
* Author: Xander 
* Date: 8/6/25
* Description: This script handles the interactivity of the player with collectibles, hazards, and doors.
  It also manages the respawn functionality and the reset of collectibles when the player respawns.
*/


public class PlayerBehaviour : MonoBehaviour
{
    bool canInteract = false; // Determines if the player is able to interact with an object
    public int collectedCount = 0; // Number of collectibles collected by the player at the start, which would be 0
    public int totalCollectibles = 5; // Total number of collectibles in the game, which would be 5

    private List<CollectibleBehaviour> allCollectibles = new List<CollectibleBehaviour>(); // List to keep track of all collectibles

    public int health = 100; // Player's health

    public Transform spawnPoint; // Player's respawn point

    public UIManager uiManager; // Reference to the UIManager script to update UI elements

    DoorBehaviour currentDoor; // Reference to the DoorBehaviour script
    CollectibleBehaviour currentCollectible; // Reference to the CollectibleBehaviour script

    public DoorBehaviour door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created



    void Start()

    {

        // Find all collectible objects in the scene and store them in a list
        CollectibleBehaviour[] foundCollectibles = FindObjectsByType<CollectibleBehaviour>(FindObjectsSortMode.None);
        foreach (CollectibleBehaviour collectible in foundCollectibles)
        {
            allCollectibles.Add(collectible);
        }

    }

    // Update is called once per frame
    void Update()

    {


        // Check if health has dropped to 0 or below
        if (health <= 0)   // If health is less than or equal to 0, respawn the player
        {
            Respawn(); // Call the respawn function
        }

    }


    void OnInteract()
    {
        if (!canInteract) return; // If player cannot interact, exit the function

        if (currentCollectible != null)
        {
            currentCollectible.Collect(this);
            collectedCount++; // Increment the count of collected items

            if (collectedCount >= totalCollectibles)
            {
                Respawn(); // Respawn the player after collecting all items
                uiManager.ShowVictoryPanel(); // Show victory panel
            }

            currentCollectible = null;
        }
        // If the player interacts with a door, call the Interact method on the door
        if (currentDoor != null)
        {
            currentDoor.Interact();
            Debug.Log("Interacted with door");
            currentDoor = null;
        }

        canInteract = false; // Reset interaction state after interaction
    }

    void OnTriggerEnter(Collider other) // Detects when the player enters a trigger collider
    {
        if (other.CompareTag("Collectible"))
        {
            currentCollectible = other.GetComponent<CollectibleBehaviour>();
            canInteract = true;
        }
        else if (other.CompareTag("Door"))
        {
            currentDoor = other.GetComponent<DoorBehaviour>();
            canInteract = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Truck")) // If player touches a truck
        {
            health -= 50; // Reduce health by 50 when hit by a truck
            if (health <= 0)
            {
                Respawn(); // Respawn the player if health drops to 0 or below
            }
        }
    }

    void Respawn()

    {
        // Temporarily disable CharacterController to move the player safely
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
            transform.position = spawnPoint.position;
            controller.enabled = true;
        }

        // Reset player stats
        health = 100;
        collectedCount = 0;

        // Respawn all collectibles using the stored references
        foreach (CollectibleBehaviour collectible in allCollectibles)  // For loop to iterate through all collectibles
        {
            collectible.Respawn();
        }

        Debug.Log("Player respawned. Collectibles reset."); // Test message to confirm respawn

        if (door != null)  // After player respawns, reset the door 

        {
            door.ResetDoor();

        }


    }



}