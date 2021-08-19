using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float thrust = 5;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        ColorChanger.colorChanged.AddListener(SetColor);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * thrust;
        }
        if (Camera.main.WorldToScreenPoint(transform.position).y < 0)
        {
            print("dead");
        }
    }

    void SetColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}