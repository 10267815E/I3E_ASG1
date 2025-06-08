using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{

    MeshRenderer myMeshRenderer;

    [SerializeField]

    Material highlightMat;

    Material originalMat;

    [SerializeField]

    int coinValue = 1; // Value of the coin
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        originalMat = myMeshRenderer.material;
    }
    public void Collect(PlayerBehaviour player)
    {
        player.gameObject.GetComponent<PlayerBehaviour>();
        Destroy(gameObject);
    }
}