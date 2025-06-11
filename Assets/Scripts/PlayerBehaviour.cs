using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.ProBuilder.Shapes;

public class PlayerBehaviour : MonoBehaviour
{
    bool canInteract = false;
    public int collectedCount = 0; // Number of collectibles collected by the player at the start, which would be 0
    public int totalCollectibles = 5; // Total number of collectibles in the game, which would be 5

    private List<CollectibleBehaviour> allCollectibles = new List<CollectibleBehaviour>();

    public int health = 100; // Player's health

    public Transform spawnPoint;

    public UIManager uiManager;

    DoorBehaviour currentDoor; // Reference to the DoorBehaviour script
    CollectibleBehaviour currentCollectible; // Reference to the CollectibleBehaviour script

    public DoorBehaviour door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created



    void Start()

    {

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
        if (!canInteract) return;

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

        if (currentDoor != null)
        {
            currentDoor.Interact();
            Debug.Log("Interacted with door");
            currentDoor = null;
        }

        canInteract = false;
    }

    void OnTriggerEnter(Collider other)
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
                Respawn();
            }
        }
    }

    void Respawn()

    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
            transform.position = spawnPoint.position;
            controller.enabled = true;
        }

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