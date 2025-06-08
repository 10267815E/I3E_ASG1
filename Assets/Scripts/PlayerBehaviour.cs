using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    bool canInteract = false;
    public int collectedCount = 0;
    public int totalCollectibles = 5;


    

    CollectibleBehaviour currentCollectible; // Reference to the CoinBehaviour script
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    


    void Start()
    {
        

    }

    // Update is called once per frame
    void Update(){
        
    }
    

    void OnInteract()
    {
        if (canInteract)
        {
            if (currentCollectible != null)
            {
                currentCollectible.Collect(this);
                Debug.Log("Interacting with coin");
            }
            

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