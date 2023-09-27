using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayScene : MonoBehaviour
{
    public void RestartGame()
    {
        //Reloading game and resetting player score when run
        SceneManager.LoadScene("SampleScene");
        MyManager.PlayerScore = 0;
    }
}
