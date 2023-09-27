using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyManager : MonoBehaviour
{
  public static MyManager Instance;

    //Varibale to hold amount of collectibles the player has gotten
    public static int PlayerScore = 0;

    //Making sure only one instance of this game manager exists
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else if (Instance != this)
        {
            Debug.Log("More than 1 instance of", this);
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }         
    }

    //Function for adding score to counter every time player grabs collectible
    public void Addscore(int scoreToAdd)
    {
        scoreToAdd = 1;
        PlayerScore += scoreToAdd;
    }

    public int GetPlayerScore()
    {
        return PlayerScore;
    }
}
