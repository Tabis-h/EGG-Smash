using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController) )]

public class PlayerMovment : MonoBehaviour
{
    private Vector2 _input;
    private float _velocity;
    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplyer = 3.0f;
    private Vector3 _direction;
    private CharacterController _charactercontroller;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed= 0.05f;
    [SerializeField] private float jumpPower;

    private Camera maincamera;
    private void Awake()
{
    _charactercontroller = GetComponent<CharacterController>();
    maincamera = Camera.main;
}

    private void Update()
    {
        ApplyRotaion();
        ApplyGravity();
        ApplyMovement();
        
    }
    
    private void ApplyMovement(){
                _charactercontroller.Move(_direction * speed * Time.deltaTime);

    }
    
    private void ApplyGravity()
    {
        if (_charactercontroller.isGrounded && _velocity<0.0f)
        {
            _velocity = -1.0f;
        }
        else{
        _velocity += _gravity * gravityMultiplyer * Time.deltaTime;
        _direction.y = _velocity;
        }
        
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
       _direction = new Vector3 (_input.x,0.0f,_input.y);
    }

    
    
    
    private void ApplyRotaion()

        {
              if(_input.sqrMagnitude ==0) return;

              _direction = Quaternion.Euler(0.0f , maincamera.transform.eulerAngles.y, 0.0f)*new Vector3(_input.x,0.0f,_input.y);
              var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
              transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }       
    

    public void Jump(InputAction.CallbackContext context)
    {
        if ( context.started) return;
        if(!_charactercontroller.isGrounded) return;


        _velocity = jumpPower;
    }

    
    
}
