using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f; // Time in seconds before the bullet self-destructs

    void Start()
    {
        // Schedule the bullet to be destroyed after lifeTime seconds
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Notify the game manager to update the score
            GameManager.Instance.PlayerHit(collision.gameObject);
        }
        
        // Destroy the bullet on collision
        Destroy(gameObject);
    }

    // Optional for 2D collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Notify the game manager to update the score
            GameManager.Instance.PlayerHit(collision.gameObject);
        }
        
        // Destroy the bullet on collision
        Destroy(gameObject);
    }
}
