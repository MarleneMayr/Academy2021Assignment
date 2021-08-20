using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItem : MonoBehaviour
{
    public float speed = 100;
    public bool clockwise;

    void Update()
    {
        // rotate according to given direction and speed
        transform.Rotate(0f, 0f, (clockwise ? -speed : speed) * Time.deltaTime);
    }
}
