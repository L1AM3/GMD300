using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    //Speed values
    public float MoveSpeed = 6;
    public float SprintSpeed = 9;
    public float RotateSpeed = 180;

    //Jumping bools
    private bool isJumping = false;

    //Movement and camera components
    public InputActionAsset CharacterActionAsset;
    public Camera FirstPersonCamera;
    private CharacterController characterController;

    //Input actions
    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    //Vector values
    private Vector2 moveValue = Vector2.zero;
    private Vector2 rotateValue = Vector2.zero;
    private Vector3 currentRotationAngle = Vector3.zero;
    private Vector3 moveDirection;

    //Other jump variables
    private float verticalMovement = 0;
    private float maxJumpHeight = 1;
    public float GroundCheckRadius = 0.25f;
    public LayerMask GroundLayer;
    public Transform GroundCheck;

    private void OnEnable()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Enable();
    }

    private void OnDisable()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Disable();
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        //Finding actions
        moveAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Move");
        rotateAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Rotation");
        sprintAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Sprint");
        jumpAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Jump");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    { 
        ProcessRotation();
        ProcessMovement();
        ProcessVerticalMovement();
    }

    void ProcessMovement()
    {
        //Sprint check
        if (sprintAction.IsPressed())
            //Apply sprint speed
            moveValue = moveAction.ReadValue<Vector2>() * SprintSpeed;
        else
            //Apply move speed
            moveValue = moveAction.ReadValue<Vector2>() * MoveSpeed;

        //Setting move dirction based on first person camera
        moveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;
        moveDirection.y = 0;
        moveDirection.y += verticalMovement;

        //Moving character based on camera direction
        characterController.Move(moveDirection * Time.deltaTime);

    }

    void ProcessVerticalMovement()
    {
        if (characterController.isGrounded && verticalMovement < 0)
        {
            isJumping = false;
            verticalMovement = 0;
        }

        bool jumpButtonDown = jumpAction.triggered && jumpAction.ReadValue<float>() > 0;
        //if(jumpButtonDown)
            //Debug.Log(jumpButtonDown);

        if (jumpButtonDown && !isJumping)
        {
            isJumping = true;
            verticalMovement += Mathf.Sqrt(maxJumpHeight * -2.0f * Physics.gravity.y);
        }

        //Adding gravity
        verticalMovement += Physics.gravity.y * Time.deltaTime;
    }

    void ProcessRotation()
    {

        //Apply rotate speed
        rotateValue = rotateAction.ReadValue<Vector2>() * RotateSpeed * Time.deltaTime;

        //Setting current rotation angle to camera angle, clamping up and down rotation
        currentRotationAngle = new Vector3(currentRotationAngle.x - rotateValue.y, currentRotationAngle.y + rotateValue.x, 0);
        FirstPersonCamera.transform.rotation = Quaternion.Euler(currentRotationAngle);
        currentRotationAngle = new Vector3(Mathf.Clamp(currentRotationAngle.x, -85, 85), currentRotationAngle.y, currentRotationAngle.z);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
