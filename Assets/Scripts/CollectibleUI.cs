using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleUI : MonoBehaviour
{
    //Variable for text element
    public TMP_Text CollectibleCounter;

    //variable for an animator
    public Animator animator;

    private void Update()
    {
        //Setting Text element equal to player score
        CollectibleCounter.text = MyManager.PlayerScore.ToString();
    }

    //Setting Key UI bool
    public void ShowKeyUI(bool showKeyUI)
    {
        animator.SetBool("showKeyUI", showKeyUI);
    }

    //Resetting Key UI bool
    public void SetFalse()
    {
        ShowKeyUI(false);
    }
}
