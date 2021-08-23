using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static UnityEvent<Player, string> playerDied = new UnityEvent<Player, string>();
    public static UnityEvent<int> scoreChanged = new UnityEvent<int>();
    public static UnityEvent<int> colorChanged = new UnityEvent<int>();

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
        // check for LMB mouse input that is not on UI object
        if (Input.GetButton("Fire1") && !EventSystem.current.IsPointerOverGameObject())
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
                CheckObstacle(other.GetComponent<ObstacleColor>());
                break;
        }
    }

    private void UpdatePlayerColor()
    {
        colorIndex = ColorPalette.instance.GetRandomNewIndex(colorIndex);
        SetColor(ColorPalette.instance.Colors[colorIndex]);
        colorChanged?.Invoke(colorIndex);
    }

    private void CheckObstacle(ObstacleColor obstacle)
    {
        if (colorIndex != obstacle.colorIndex)
        {
            playerDied?.Invoke(this, "oh no, you touched the wrong color");
        }
    }
}