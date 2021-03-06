using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneVars : MonoBehaviour
{
    public static Color CurrentColor = Color.green;
    public static ColoringType CurrentColoringType = ColoringType.Pouring;
    public static bool EraserSpawned = false;
}

public enum ColoringType
{
    Brush,
    Pouring,
    Eraser
}