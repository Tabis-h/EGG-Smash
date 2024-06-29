using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardforce = 2000f;
    public float sidewaysforce = 500f;
    public float jumpforce = 500f; 
    private bool isGrounded;
    

    void Update()
    {
        // Move left
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Move right
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Move forward
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardforce * Time.deltaTime, ForceMode.VelocityChange);
        }

        // Move backward
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardforce * Time.deltaTime, ForceMode.VelocityChange);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0, jumpforce, 0, ForceMode.Impulse);
            isGrounded = false; // Set isGrounded to false to prevent double jumping
        }
    }

    // Detect collision with ground
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
    }

    // Detect when the player is no longer colliding with the ground
    void OnCollisionExit(Collision collision)
    {
        // Check if the player is no longer touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; 
        }
    }
}
