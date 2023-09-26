using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonInteract : MonoBehaviour
{
    public bool ButtonPressed = false;
    public UnityEvent OnButtonPress;
    public ButtonPressAnimation ButtonPressAnimation;

    public void OnPlayerInteract()
    {
        OnButtonPress.Invoke();

        ButtonPressed = true;
        Debug.Log(ButtonPressed);
        ButtonPressAnimation.ButtonPressAnim(ButtonPressed);

        Invoke("Delay", 5);
    }

    private void Delay()
    {
        ButtonPressed = false;
        ButtonPressAnimation.ButtonPressReset(ButtonPressed);
    }
}
