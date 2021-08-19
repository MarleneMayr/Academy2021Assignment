using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static UnityEvent<Player, string> playerDied = new UnityEvent<Player, string>();

    [SerializeField] private float thrust = 5;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        ColorChanger.colorChanged.AddListener(SetColor);
        playerDied.AddListener((player, message) => Destroy(player.gameObject));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * thrust;
        }
        if (Camera.main.WorldToScreenPoint(transform.position).y < 0)
        {
            playerDied?.Invoke(this, "you fell to the floor");
        }
    }

    void SetColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}