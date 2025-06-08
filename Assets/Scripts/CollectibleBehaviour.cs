using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{

    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void Collect(PlayerBehaviour player)
    {
        player.gameObject.GetComponent<PlayerBehaviour>();
        Destroy(gameObject);
    }
}