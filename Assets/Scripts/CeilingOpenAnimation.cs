using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingOpenAnimation : MonoBehaviour
{
    //variable for an animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //getting the animator on the object
        anim = GetComponent<Animator>();   
    }

    public void DoorOpenAnimation(bool AllKeys)
    {
        //Function for playing the ceiling animation
        anim.SetBool("KeysCollected", AllKeys);
    }
}
