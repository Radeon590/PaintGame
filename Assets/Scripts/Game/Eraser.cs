using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    public Touch touch;

    void Update()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(touch.position);
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(touch.phase == TouchPhase.Ended)
        {
            SingletoneVars.EraserSpawned = false;
            Destroy(gameObject);
        }
        if (Input.GetMouseButtonUp(0))
        {
            SingletoneVars.EraserSpawned = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Brush")
        {
            Destroy(other.gameObject);
        }
    }
}
