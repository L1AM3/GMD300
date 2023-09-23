using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleUI : MonoBehaviour
{
    public TMP_Text CollectibleCounter;

    private void Update()
    {
        CollectibleCounter.text = MyManager.playerScore.ToString();
    }
}
