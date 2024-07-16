using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Reference to the bullet prefab
    public Transform firePoint;       // Reference to the point where the bullet will be instantiated
    public float bulletSpeed = 100f;   // Speed of the bullet
    public float fireRate = 1f;       // Rate of fire (bullets per second)
    private float nextFireTime = 0f;  // Time when the player can fire next

    void Update()
    {
        // Check if the fire button is pressed and if enough time has passed since the last shot
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Handle 3D physics
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
            rb.useGravity = false; // Ensure gravity is disabled
        }
        
        // Handle 2D physics
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        if (rb2D != null)
        {
            rb2D.velocity = firePoint.right * bulletSpeed;
            rb2D.gravityScale = 0; // Ensure gravity is disabled
        }
    }
}
