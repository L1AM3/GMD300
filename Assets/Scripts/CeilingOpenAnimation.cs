using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingOpenAnimation : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    public void DoorOpenAnimation(bool AllKeys)
    {
        anim.SetBool("KeysCollected", AllKeys);
    }
}
