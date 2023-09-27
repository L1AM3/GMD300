using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotate : MonoBehaviour
{
    //Setting speed for key rotation
    public float RotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        //Rotating key based on update
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);  
    }
}
