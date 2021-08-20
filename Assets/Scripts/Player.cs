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
    private int colorIndex;
    private void SetColor(Color newColor) => spriteRenderer.color = newColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorIndex = ColorPalette.instance.GetRandomIndex();
        SetColor(ColorPalette.instance.Colors[colorIndex]);

        rb = GetComponent<Rigidbody2D>();
        playerDied.AddListener((player, message) => Destroy(player.gameObject));
    }

    private void Update()
    {
        // check for mouse input
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
        switch (other.tag)
        {
            case "Score":
                Destroy(other.gameObject);
                score++;
                scoreChanged?.Invoke(score);
                break;
            case "ColorSwitch":
                Destroy(other.gameObject);
                UpdatePlayerColor();
                break;
            case "Obstacle":
                CheckObstacle(other.GetComponent<Obstacle>());
                break;
        }
    }

    private void UpdatePlayerColor()
    {
        colorIndex = ColorPalette.instance.GetRandomNewIndex(colorIndex);
        SetColor(ColorPalette.instance.Colors[colorIndex]);
    }
    private void CheckObstacle(Obstacle obstacle)
    {
        if (colorIndex != obstacle.colorIndex)
        {
            playerDied?.Invoke(this, "oh no, you touched the wrong color");
        }
    }
}