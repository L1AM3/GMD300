using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressAnimation : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ButtonPressAnim(bool ButtonPressed)
    {
        anim.SetBool("Buttonpressed", ButtonPressed);
    }

    public void ButtonPressReset(bool ButtonPressed)
    {
        anim.SetBool("Buttonpressed", ButtonPressed);
    }

}
