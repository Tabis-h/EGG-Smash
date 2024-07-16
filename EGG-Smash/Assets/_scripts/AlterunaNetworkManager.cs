using UnityEngine;
using Alteruna;

public class AlterunaNetworkManager : MonoBehaviour
{
    public static AlterunaNetworkManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to update player score on the network
    public void UpdatePlayerScore(GameObject player, int score)
    {
        // Example function call to Alteruna for updating player score
        // You'll need to implement the actual network update logic using Alteruna's API
       
    }
}
