using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    bool canInteract = false;
    public int collectedCount = 0;
    public int totalCollectibles = 5;

    public int health = 100; // Player's health


    

    CollectibleBehaviour currentCollectible; // Reference to the CollectibleBehaviour script
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    


    void Start()
    {
        

    }

    // Update is called once per frame
    void Update(){
        
    }
    

    void OnInteract()
   {
    if (canInteract && currentCollectible != null)
     {
        currentCollectible.Collect(this);
        collectedCount++;

        Debug.Log("Collected item. Count: " + collectedCount);

        if (collectedCount >= totalCollectibles)
        {
            Debug.Log("All items collected! You win!");
            // TODO: Trigger a UI message later
        }

        // Reset interaction
        currentCollectible = null;
        canInteract = false;
     }
   } 
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Collectible"))
        {
            canInteract = true;
            currentCollectible = other.GetComponent<CollectibleBehaviour>();
        }
        

    }

    

    
}