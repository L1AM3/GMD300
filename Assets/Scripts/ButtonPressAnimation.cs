using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressAnimation : MonoBehaviour
{
    //variable for an animator
    public Animator Anim;

    private void Start()
    {
        //getting the animator on the object
        Anim = GetComponent<Animator>();
    }

    //Function for playing the button animation
    public void ButtonPressAnim(bool ButtonPressed)
    {
        Anim.SetBool("Buttonpressed", ButtonPressed);
    }

    //Function for undoing the variable for button animation
    public void ButtonPressReset(bool ButtonPressed)
    {
        Anim.SetBool("Buttonpressed", ButtonPressed);
    }

}
