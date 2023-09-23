using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

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

        animator = GetComponent<Animator>();
    }


    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
  

    public void ShowInteractPrompt(bool showPrompt)
    {
        animator.SetBool("showInteractionPrompt", showPrompt);
    }

    public void ShowKeyUI(bool showKeyUI)
    {
        animator.SetBool("showKeyUI", showKeyUI);
    }

}
