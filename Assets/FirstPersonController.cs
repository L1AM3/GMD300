using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{

    public float MoveSpeed = 3;
    public float RotateSpeed = 180;

    public InputActionAsset CharacterActionAsset;

    public Camera FirstPersonCamera;

    private InputAction moveAction;
    private InputAction rotateAction;

    private CharacterController characterController;

    private Vector2 moveValue = Vector2.zero;
    private Vector2 rotateValue = Vector2.zero;
    private Vector3 currentRotationAngle = Vector3.zero;

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

        moveAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Move");
        rotateAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Rotation");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(moveAction.ReadValue<Vector2>());

        moveValue = moveAction.ReadValue<Vector2>() * MoveSpeed * Time.deltaTime;
        rotateValue = rotateAction.ReadValue<Vector2>() * RotateSpeed * Time.deltaTime;

        currentRotationAngle = new Vector3(currentRotationAngle.x - rotateValue.y, currentRotationAngle.y + rotateValue.x, 0);

        currentRotationAngle = new Vector3(Mathf.Clamp(currentRotationAngle.x, -85, 85), currentRotationAngle.y, currentRotationAngle.z);

        FirstPersonCamera.transform.rotation = Quaternion.Euler(currentRotationAngle);

        characterController.Move(new Vector3(moveValue.x, 0, moveValue.y));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
