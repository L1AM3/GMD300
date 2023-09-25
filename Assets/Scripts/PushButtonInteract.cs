using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonInteract : MonoBehaviour
{
    public UnityEvent OnButtonPress;
    public ButtonPressAnimation ButtonPressAnimation;

    public void OnPlayerInteract()
    {
        Debug.Log("Hit");   
        OnButtonPress.Invoke();
        ButtonPressAnimation.ButtonPressAnim();
    }
}
