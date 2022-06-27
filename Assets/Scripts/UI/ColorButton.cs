using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private Color color;

    public void OnColorSelect()
    {
        SingletoneVars.CurrentColor = color;
    }
}
