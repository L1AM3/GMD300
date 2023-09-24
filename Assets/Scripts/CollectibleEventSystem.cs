using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CollectibleEventSystem : MonoBehaviour
{
    //Creating variable to grab information from manager script
    public int ScoreToAdd;

    public CollectibleUI collectible;

    //Event systems for collectibles
    public UnityEvent CollectibleOne;
    public UnityEvent CollectibleTwo;
    public UnityEvent CollectibleThree;
    public UnityEvent CollectibleFour;
    public UnityEvent CollectibleFive;
    public UnityEvent CollectibleSix;
    public UnityEvent AllCollectiblesGot;

    //Getting colliders of collectibles
    public Component CollecitbleOneCollider;
    public Component CollecitbleTwoCollider;
    public Component CollecitbleThreeCollider;
    public Component CollecitbleFourCollider;
    public Component CollecitbleFiveCollider;
    public Component CollecitbleSixCollider;

    private void Update()
    {
        //Checking for if the player has collected all collectibles and then opening door out
        if (MyManager.playerScore >= 6)
        {
            AllCollectiblesGot.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //Checking which collectible the player has gotten and setting them inactive and adding score to player's total
        if (other == CollecitbleOneCollider)
        {
            collectible.ShowKeyUI(true);
            CollectibleOne.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleTwoCollider)
        {
            collectible.ShowKeyUI(true);
            CollectibleTwo.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleThreeCollider)
        {
            collectible.ShowKeyUI(true);
            CollectibleThree.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleFourCollider)
        {
            collectible.ShowKeyUI(true);
            CollectibleFour.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleFiveCollider)
        {
            collectible.ShowKeyUI(true);
            CollectibleFive.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleSixCollider)
        {
            collectible.ShowKeyUI(true);
            CollectibleSix.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
    }
}
