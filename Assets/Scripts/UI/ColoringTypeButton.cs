using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringTypeButton : MonoBehaviour
{
    [SerializeField] private ColoringType coloringType;

    public void OnColoringTypeSelect()
    {
        SingletoneVars.CurrentColoringType = coloringType;
    }
}
