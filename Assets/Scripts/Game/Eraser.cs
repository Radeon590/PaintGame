using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    private float _deathTimer = 1;

    void Update()
    {
        _deathTimer -= Time.deltaTime;
        if (_deathTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Destroy(other.gameObject);
    }
}
