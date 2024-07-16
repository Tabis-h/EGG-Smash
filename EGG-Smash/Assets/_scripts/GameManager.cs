using UnityEngine;
using System.Collections.Generic;
using Alteruna;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private Dictionary<GameObject, int> playerScores = new Dictionary<GameObject, int>();

    void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
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

    // Call this method when a player is hit by a bullet
    public void PlayerHit(GameObject player)
    {
        if (playerScores.ContainsKey(player))
        {
            playerScores[player]++;
        }
        else
        {
            playerScores[player] = 1;
        }

        // Update the score on the network
        UpdatePlayerScoreOnNetwork(player, playerScores[player]);
    }

    public int GetPlayerScore(GameObject player)
    {
        if (playerScores.ContainsKey(player))
        {
            return playerScores[player];
        }
        return 0;
    }

    private void UpdatePlayerScoreOnNetwork(GameObject player, int score)
    {
        // Implement network synchronization using Alteruna
        AlterunaNetworkManager.Instance.UpdatePlayerScore(player, score);
    }
}
