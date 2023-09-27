using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExplosion : MonoBehaviour
{
    //Variable for particle system
    public ParticleSystem Explosion;
    public void DESTROY()
    {
        //Instantiating particle system where door was
        Instantiate(Explosion, transform.position, transform.rotation);

        //Destroying after explosion
        Destroy(this.gameObject);
    }
}
