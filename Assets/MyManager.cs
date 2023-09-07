using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyManager : MonoBehaviour
{
  public static MyManager Instance;

    public int playerScore;

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

    public void Addscore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
    }
}
