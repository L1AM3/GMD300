using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonInteract : MonoBehaviour
{
    //Variables for setting up the animation
    public bool ButtonPressed = false;
    public UnityEvent OnButtonPress;
    public ButtonPressAnimation ButtonPressAnimation;

    //When player interacts with button this will play
    public void OnPlayerInteract()
    {
        OnButtonPress.Invoke();

        //Setting bool so animation will play
        ButtonPressed = true;
        Debug.Log(ButtonPressed);
        ButtonPressAnimation.ButtonPressAnim(ButtonPressed);

        //Delaying bool change
        Invoke("Delay", 5);
    }

    private void Delay()
    {
        //Reseting bool to allow animation to play again
        ButtonPressed = false;
        ButtonPressAnimation.ButtonPressReset(ButtonPressed);
    }
}
