using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchEventSystem : MonoBehaviour
{
    //Event systems for buttons
    public UnityEvent ButtonOnePress;
    public UnityEvent ButtonTwoPress;
    public UnityEvent ButtonThreePress;
    public UnityEvent ButtonFourPress;
    public UnityEvent ButtonFivePress;

    //Getting colliders of door buttons
    public Component ButtonOneCollider;
    public Component ButtonTwoCollider;
    public Component ButtonThreeCollider;
    public Component ButtonFourCollider;
    public Component ButtonFiveCollider;

    private void OnTriggerEnter(Collider other)
    {
        //if statements to check each button collider collison
        if (other == ButtonOneCollider)
        {
            ButtonOnePress.Invoke();
        }
        else if (other == ButtonTwoCollider)
        {
            ButtonTwoPress.Invoke();
        }
        else if (other == ButtonThreeCollider)
        {
            ButtonThreePress.Invoke();
        }
        else if (other == ButtonFourCollider)
        {
            ButtonFourPress.Invoke();
        }
        else if (other == ButtonFiveCollider)
        {
            ButtonFivePress.Invoke();
        }
    }

}
