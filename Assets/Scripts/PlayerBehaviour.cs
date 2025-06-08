using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    bool canInteract = false;


    [SerializeField]

    GameObject projectile;

    [SerializeField]

    Transform spawnPoint;

    [SerializeField]

    float fireStrength = 0f;

    CoinBehaviour currentCoin; // Reference to the CoinBehaviour script
    
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
            if (currentCoin != null)
            {
                currentCoin.Collect(this);
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
            currentCoin = other.GetComponent<CoinBehaviour>();
        }
        

    }

    void OnFire()
    {
        GameObject newProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        Vector3 fireForce = spawnPoint.forward * fireStrength;

        newProjectile.GetComponent<Rigidbody>().AddForce(fireForce);
    }

    




}