using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{

    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Collect(PlayerBehaviour player)
    {
        // Disable the collectible object
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
    }
}