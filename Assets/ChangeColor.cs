using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color newColor;

  public void ChangesColor()
    {
        GetComponent<Light>().color = newColor;
    }
}
