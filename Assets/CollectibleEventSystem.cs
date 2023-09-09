using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CollectibleEventSystem : MonoBehaviour
{
    public int ScoreToAdd;

    public UnityEvent CollectibleOne;
    public UnityEvent CollectibleTwo;
    public UnityEvent CollectibleThree;
    public UnityEvent CollectibleFour;
    public UnityEvent CollectibleFive;
    public UnityEvent CollectibleSix;
    public UnityEvent AllCollectiblesGot;

    public Component CollecitbleOneCollider;
    public Component CollecitbleTwoCollider;
    public Component CollecitbleThreeCollider;
    public Component CollecitbleFourCollider;
    public Component CollecitbleFiveCollider;
    public Component CollecitbleSixCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (MyManager.Instance.playerScore == 6)
        {
            AllCollectiblesGot.Invoke();
        }
        else if (other == CollecitbleOneCollider)
        {
            CollectibleOne.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        else if (other == CollecitbleTwoCollider)
        {
            CollectibleTwo.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        else if (other == CollecitbleThreeCollider)
        {
            CollectibleThree.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        else if (other == CollecitbleFourCollider)
        {
            CollectibleFour.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        else if (other == CollecitbleFiveCollider)
        {
            CollectibleFive.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
        else if (other == CollecitbleSixCollider)
        {
            CollectibleSix.Invoke();
            MyManager.Instance.Addscore(ScoreToAdd);
        }
    }
}
