using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    //Speed values
    public float MoveSpeed = 6;
    public float SprintSpeed = 9;
    public float RotateSpeed = 2500;

    //bool isJumping = false;

    public InputActionAsset CharacterActionAsset;

    public Camera FirstPersonCamera;

    //Input actions
    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    private CharacterController characterController;

    //Vector values
    private Vector2 moveValue = Vector2.zero;
    private Vector2 rotateValue = Vector2.zero;
    private Vector3 currentRotationAngle = Vector3.zero;
    private Vector3 moveDirection;

    private float verticalMovement = 0;
    private float MaxJumpHeight = 1;

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
            moveValue = moveAction.ReadValue<Vector2>() * SprintSpeed * Time.deltaTime;
        else
            //Apply move speed
            moveValue = moveAction.ReadValue<Vector2>() * MoveSpeed * Time.deltaTime;

        //Setting move dirction based on first person camera
        moveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;
        moveDirection.y = 0;

        //Moving character based on camera direction
        characterController.Move(new Vector3(moveDirection.x, verticalMovement, moveDirection.z));

    }

    void ProcessVerticalMovement()
    {
        bool jumpButtonDown = jumpAction.triggered && jumpAction.ReadValue<float>() > 0;

        if (jumpButtonDown)
        {
            //isJumping = true;

            verticalMovement += Mathf.Sqrt(MaxJumpHeight * -2.0f * Physics.gravity.y);
        }

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

    void ApplyMovement()
    {

    }


    void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
