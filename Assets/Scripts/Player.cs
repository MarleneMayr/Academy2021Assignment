using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    void Start()
    {
        ColorChanger.colorChanged.AddListener(SetColor);
    }

    void SetColor(Color newColor)
    {
        GetComponent<SpriteRenderer>().color = newColor;
    }
}