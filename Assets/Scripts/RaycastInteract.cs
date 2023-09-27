using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastInteract : MonoBehaviour
{
    //Variables setting up camera and distance from it
    public Camera PlayerCamera;
    public float Distance = 1;

    //Variables getting input action stuff
    public InputActionAsset CharacterInputActions;
    public InputAction interactAction;

    private void Awake()
    {
        //Getting the input for interaction
        CharacterInputActions.FindActionMap("Gameplay").FindAction("Interact");
        
        //Setting it to equal interactAction
        interactAction = CharacterInputActions.FindActionMap("Gameplay").FindAction("Interact");
    }

    private void OnDisable()
    {
        CharacterInputActions.FindActionMap("Gameplay").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Setting up Raycast
        Ray interactionRay = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
        RaycastHit interactionHitInfo;
        Physics.Raycast(interactionRay, out interactionHitInfo, 1);

        //Setting conditions of bool
        bool interactInputPressed = interactAction.triggered && interactAction.ReadValue<float>() > 0;

        //Normally prompt won't show up
        bool showInteractPrompt = false;

        //Checking if raycast distance conditions are satisfied
        if (Physics.Raycast(interactionRay, out interactionHitInfo, Distance))
        {
            //Seeing if the object is tagged with interactible
            if (interactionHitInfo.transform.tag == "Interactible")
            {
                //Showing prompt while looking at raycast object
                showInteractPrompt = true;
                if (interactInputPressed)
                {
                    //Sending message that it was interacted with
                    interactionHitInfo.transform.SendMessage("OnPlayerInteract", SendMessageOptions.DontRequireReceiver);

                }
            }
        }
        UIManager.Instance.ShowInteractPrompt(showInteractPrompt);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(PlayerCamera.transform.position, PlayerCamera.transform.forward);
    }
}
