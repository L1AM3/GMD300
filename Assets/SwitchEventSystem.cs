using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchEventSystem : MonoBehaviour
{
    public UnityEvent ButtonOnePress;
    public UnityEvent ButtonTwoPress;
    public UnityEvent ButtonThreePress;
    public UnityEvent ButtonFourPress;
    public UnityEvent ButtonFivePress;

    public Component ButtonOneCollider;
    public Component ButtonTwoCollider;
    public Component ButtonThreeCollider;
    public Component ButtonFourCollider;
    public Component ButtonFiveCollider;

    private void OnTriggerEnter(Collider other)
    {
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
