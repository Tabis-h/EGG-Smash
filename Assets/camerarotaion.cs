using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public float sensitivity = 0.5f;
    public float speed = 1;
    public GameObject mover; // Assign the player GameObject here

    private float rotationX = 0f; // Current rotation around X-axis (for camera pitch)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Check if mover is assigned
        if (mover == null)
        {
            Debug.LogWarning("Player object is not assigned in the MouseCamera script.");
            return;
        }

        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Update rotation based on mouse input
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Apply horizontal rotation to the player (mover)
        mover.transform.localRotation = Quaternion.Euler(0, mouseX * sensitivity, 0) * mover.transform.localRotation;

        // Calculate camera position relative to player's forward direction
        Vector3 desiredCameraPosition = mover.transform.position - mover.transform.forward * 5f; // Adjust distance as needed
        desiredCameraPosition.y = mover.transform.position.y + 2f; // Adjust height as needed

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredCameraPosition, speed * Time.deltaTime);

        // Look at the player (mover)
        transform.LookAt(mover.transform.position + mover.transform.up * 2f); // Adjust look offset as needed

        // Apply movement to the mover (player)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = mover.transform.right * moveX + mover.transform.forward * moveZ;
        moveDirection *= speed * Time.deltaTime;
        mover.transform.position += moveDirection;
    }
}
