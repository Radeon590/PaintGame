using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    public Touch touch;
    //
    private float _deathTimer = 0.5f;

    void Update()
    {
        /*_deathTimer -= Time.deltaTime;
        if (_deathTimer < 0)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Brush")
        {
            Destroy(other.gameObject);
        }
    }
}
