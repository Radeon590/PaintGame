using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneVars : MonoBehaviour
{
    public static Color CurrentColor;
    public static ColoringType CurrentColoringType;

    public void UpdateColoringType()
    {

    }
}

public enum ColoringType
{
    Brush,
    Pouring
}