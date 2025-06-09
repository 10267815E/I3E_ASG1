using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    bool canInteract = false;
    public int collectedCount = 0;
    public int totalCollectibles = 5;

    public int health = 100; // Player's health

    public Transform spawnPoint;

    DoorBehaviour currentDoor; // Reference to the DoorBehaviour script




    CollectibleBehaviour currentCollectible; // Reference to the CollectibleBehaviour script

    // Start is called once before the first execution of Update after the MonoBehaviour is created



    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnInteract()
    {
        if (!canInteract) return;

        if (currentCollectible != null)
        {
            currentCollectible.Collect(this);
            collectedCount++;

            Debug.Log("Collected item. Count: " + collectedCount);

            if (collectedCount >= totalCollectibles)
            {
                Debug.Log("All items collected! You win!");
                // TODO: Trigger a UI message later
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
        if (collision.gameObject.CompareTag("Truck"))
        {
            health -= 50; // Reduce health by 50 when hit by a truck
        }
    }




}