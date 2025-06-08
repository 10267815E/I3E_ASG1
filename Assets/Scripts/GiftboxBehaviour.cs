using UnityEngine;

public class GiftboxBehaviour : MonoBehaviour
{
    [SerializeField]

    GameObject coin;

    [SerializeField]

    Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject newCoin = Instantiate(coin,spawnPoint.position, spawnPoint.rotation);
        }
        
    }
}
