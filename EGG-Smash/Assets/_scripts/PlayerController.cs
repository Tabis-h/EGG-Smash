using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Base setup")]
    static public float walkingSpeed = 7.5f;
    static public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    [SerializeField]
    private float cameraDistance = 5.0f;
    [SerializeField]
    private float cameraHeight = 2.0f;
    private Camera playerCamera;

    private Alteruna.Avatar _avatar;

    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();

        if (!_avatar.IsMe)
            return;
        
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (!_avatar.IsMe)
            return;

        // Camera control
        if (canMove && playerCamera != null)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            float rotationY = Input.GetAxis("Mouse X") * lookSpeed;

            transform.rotation *= Quaternion.Euler(0, rotationY, 0);

            Vector3 cameraOffset = new Vector3(0, cameraHeight, -cameraDistance);
            Quaternion cameraRotation = Quaternion.Euler(rotationX, transform.eulerAngles.y, 0);
            playerCamera.transform.position = transform.position + cameraRotation * cameraOffset;
            playerCamera.transform.LookAt(transform.position + Vector3.up * cameraHeight);
        }
    }

    void Update()
    {
        if (!_avatar.IsMe)
            return;
        
        bool isRunning = false;

        
        isRunning = Input.GetKey(KeyCode.LeftShift);

       
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
