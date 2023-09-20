using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastInteract : MonoBehaviour
{
    public Camera playerCamera;
    public float distance = 1;

    public InputActionAsset CharacterInputActions;
    public InputAction interactAction;

    private void Awake()
    {
        CharacterInputActions.FindActionMap("Gameplay").FindAction("Interact");

        interactAction = CharacterInputActions.FindActionMap("Gameplay").FindAction("Interact");
    }

    private void OnDisable()
    {
        CharacterInputActions.FindActionMap("Gameplay").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Ray interactionRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit interactionHitInfo;
        Physics.Raycast(interactionRay, out interactionHitInfo, 1);

        bool interactInputPressed = interactAction.triggered && interactAction.ReadValue<float>() > 0;

        bool showInteractPrompt = false;

        if (Physics.Raycast(interactionRay, out interactionHitInfo, distance))
        {

            if (interactionHitInfo.transform.tag == "Interactible")
            {
                showInteractPrompt = true;
                if (interactInputPressed)
                {
                    interactionHitInfo.transform.SendMessage("OnPlayerInteract", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("works");

                }
            }
        }
        UIManager.Instance.ShowInteractPrompt(showInteractPrompt);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward);
    }
}
