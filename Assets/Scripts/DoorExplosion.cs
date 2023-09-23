using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExplosion : MonoBehaviour
{
    public ParticleSystem explosion;
    public void DESTROY()
    {
        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}
