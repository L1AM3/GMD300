using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleUI : MonoBehaviour
{
    public TMP_Text CollectibleCounter;

    public Animator animator;

    private void Update()
    {
        CollectibleCounter.text = MyManager.playerScore.ToString();
    }

    public void ShowKeyUI(bool showKeyUI)
    {
        animator.SetBool("showKeyUI", showKeyUI);
    }

    public void SetFalse()
    {
        ShowKeyUI(false);
    }
}
