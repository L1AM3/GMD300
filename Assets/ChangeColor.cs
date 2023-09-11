using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color NewColor;

  public void ChangesColor()
    {
        //Getting component to change light color of
        GetComponent<Light>().color = NewColor;
    }
}
