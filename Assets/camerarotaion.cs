using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 0.5f;
    public Vector3 deltaMove;
    public float speed = 1;
    public GameObject mover;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Update rotation based on mouse input
        turn.x += mouseX * sensitivity;
        turn.y += mouseY * sensitivity;

        // Clamp the vertical rotation
        turn.y = Mathf.Clamp(turn.y, -90f, 90f);

        // Apply horizontal rotation to the mover
        if (mover != null)
        {
            Quaternion targetRotation = Quaternion.Euler(0, turn.x, 0);
            mover.transform.localRotation = Quaternion.Slerp(mover.transform.localRotation, targetRotation, Time.deltaTime * 5f);
        }

        // Apply vertical rotation to the camera itself
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);

        // Get movement input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Calculate move direction relative to the mover's rotation
        Vector3 moveDirection = mover.transform.right * moveX + mover.transform.forward * moveZ;
        moveDirection *= speed * Time.deltaTime;

        // Apply movement to the mover
        mover.transform.position += moveDirection;
    }
}
