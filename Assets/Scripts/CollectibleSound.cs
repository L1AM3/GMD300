using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollectibleSound : MonoBehaviour
{
    //Variables to set up audio player
    public AudioClip PickUpNoise;
    public AudioSource Collectible;

    public void PlayCollectibleSound()
    {
        //Making sure audio can't overlap
        Collectible.Stop();
        //Plays chosen audio clip
        Collectible.clip = PickUpNoise;
        Collectible.Play();
    }

}
