using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static UnityEvent<Player, string> playerDied = new UnityEvent<Player, string>();
    public static UnityEvent<int> scoreChanged = new UnityEvent<int>();

    [SerializeField] private float thrust = 5;
    private int score = 0;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public void SetColor(Color newColor)
    {
        spriteRenderer ??= GetComponent<SpriteRenderer>();
        spriteRenderer.color = newColor;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerDied.AddListener((player, message) => Destroy(player.gameObject));
    }

    private void Update()
    {
        // check for input
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * thrust;
        }
        // check if player has fallen to the floor
        if (Camera.main.WorldToScreenPoint(transform.position).y < 0)
        {
            playerDied?.Invoke(this, "you fell to the floor");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Score")
        {
            Destroy(other.gameObject);
            score++;
            scoreChanged?.Invoke(score);
        }
    }
}