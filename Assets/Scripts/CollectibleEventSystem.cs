using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CollectibleEventSystem : MonoBehaviour
{
    //Variables for end condition
    public CeilingOpenAnimation CeilingOpen;
    public bool AllKeys = false;

    //Creating variable to grab information from manager script
    public int ScoreToAdd;

    //Reference to CollectibleUI script
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
        //Checking for if the player has collected all keys and then opening door out
        if (MyManager.PlayerScore >= 6)
        {
            //Setting bool to true for animator
            AllKeys = true;
            CeilingOpen.DoorOpenAnimation(AllKeys);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //Checking which collectible the player has gotten and setting them inactive and adding score to player's total
        if (other == CollecitbleOneCollider)
        {
            //Happens after player gets first key
            Collectible.ShowKeyUI(true);
            CollectibleOne.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleTwoCollider)
        {
            //Happens after player gets second key
            Collectible.ShowKeyUI(true);
            CollectibleTwo.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleThreeCollider)
        {
            //Happens after player gets third key
            Collectible.ShowKeyUI(true);
            CollectibleThree.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleFourCollider)
        {
            //Happens after player gets fourth key
            Collectible.ShowKeyUI(true);
            CollectibleFour.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleFiveCollider)
        {
            //Happens after player gets fifth key
            Collectible.ShowKeyUI(true);
            CollectibleFive.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        if (other == CollecitbleSixCollider)
        {
            //Happens after player gets sixth key
            Collectible.ShowKeyUI(true);
            CollectibleSix.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
    }
}
