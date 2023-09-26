using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CollectibleEventSystem : MonoBehaviour
{
    public CeilingOpenAnimation CeilingOpen;
    public bool AllKeys = false;

    //Creating variable to grab information from manager script
    public int ScoreToAdd;

    public CollectibleUI Collectible;

    //Event systems for collectibles
    public UnityEvent CollectibleOne;
    public UnityEvent CollectibleTwo;
    public UnityEvent CollectibleThree;
    public UnityEvent CollectibleFour;
    public UnityEvent CollectibleFive;
    public UnityEvent CollectibleSix;

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
            AllKeys = true;
            CeilingOpen.DoorOpenAnimation(AllKeys);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //Checking which collectible the player has gotten and setting them inactive and adding score to player's total
        if (other == CollecitbleOneCollider)
        {
            Collectible.ShowKeyUI(true);
            CollectibleOne.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleTwoCollider)
        {
            Collectible.ShowKeyUI(true);
            CollectibleTwo.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleThreeCollider)
        {
            Collectible.ShowKeyUI(true);
            CollectibleThree.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleFourCollider)
        {
            Collectible.ShowKeyUI(true);
            CollectibleFour.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleFiveCollider)
        {
            Collectible.ShowKeyUI(true);
            CollectibleFive.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleSixCollider)
        {
            Collectible.ShowKeyUI(true);
            CollectibleSix.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
    }
}
