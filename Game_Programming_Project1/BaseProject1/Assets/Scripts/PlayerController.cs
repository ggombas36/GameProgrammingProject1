using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private float speed = 5f;
    private Rigidbody2D _rigidbody2D;

    private PlayerControls playerInput;
    private float horizontalInput;
    private float verticalInput;

    //private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerInput = InputManager.Instance.GetInputActions();

        playerInput.Player.HorizontalMovement.performed += HorizontalMovement_performed;
        playerInput.Player.HorizontalMovement.canceled += HorizontalMovement_canceled;
        playerInput.Player.VerticalMovement.performed += VerticalMovement_performed;
        playerInput.Player.VerticalMovement.canceled += VerticalMovement_canceled;
    }


    private void OnDestroy()
    {

        playerInput.Player.HorizontalMovement.performed -= HorizontalMovement_performed;
        playerInput.Player.HorizontalMovement.canceled -= HorizontalMovement_canceled;
        playerInput.Player.VerticalMovement.performed -= VerticalMovement_performed;
        playerInput.Player.VerticalMovement.canceled -= VerticalMovement_canceled;

    }

    private bool isMovingHorizontally = false;
    private bool isMovingVertically = false;

    private void VerticalMovement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isMovingHorizontally)
        {
            verticalInput = obj.ReadValue<float>();
            isMovingVertically = true;
        }
        
    }

    private void VerticalMovement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        verticalInput = obj.ReadValue<float>();
        isMovingVertically = false;
        
        
    }


    private void HorizontalMovement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isMovingVertically)
        {
            horizontalInput = obj.ReadValue<float>();
            isMovingHorizontally = true;
        }

        
    }

    private void HorizontalMovement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        horizontalInput = obj.ReadValue<float>();
        isMovingHorizontally = false;
    }



    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
    }

    private void Update()
    {
        //_animator.SetFloat("HorizontalVelocity", Mathf.Abs(_rigidbody2D.velocity.x));
        //_animator.SetFloat("VerticalVelocity", _rigidbody2D.velocity.y);
        //_animator.SetBool("Grounded", grounded);
    }

 

}
