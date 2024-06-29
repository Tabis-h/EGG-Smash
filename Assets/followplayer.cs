using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Adjust offset as needed
    public float smoothSpeed = 10f; // Smoothing factor for camera movement
    public float fixedY = 2f; // Fixed Y position for the camera

    void LateUpdate()
    {
        // Assuming the camera is a child of the player GameObject
        Transform playerTransform = transform.parent; // Get the parent transform (player)

        if (playerTransform != null)
        {
            // Calculate the desired position of the camera
            Vector3 targetPosition = playerTransform.position + offset;
            targetPosition.y = fixedY; // Keep Y position constant

            // Smoothly interpolate towards the desired position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
