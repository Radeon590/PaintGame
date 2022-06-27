using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoringObject : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TouchController.onTouch += OnTouch;
    }

    public void OnTouch(Vector2 touchPos)
    {
        Debug.Log("touch event");
        if (touchPos.x > spriteRenderer.bounds.min.x &&
            touchPos.x < spriteRenderer.bounds.max.x &&
            touchPos.y > spriteRenderer.bounds.min.y &&
            touchPos.y < spriteRenderer.bounds.max.y)
        {
            spriteRenderer.color = SingletoneVars.CurrentColor;
        }
    }
}
