using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIManager : MonoBehaviour
{
    //Making UIManger a static
    public static UIManager Instance;

    //variable for an animator
    private Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        //Getting animator off of object
        animator = GetComponent<Animator>();
    }


    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
  
    //When played sets bool on animator to true and will show prompt
    public void ShowInteractPrompt(bool showPrompt)
    {
        animator.SetBool("showInteractionPrompt", showPrompt);
    }
}
