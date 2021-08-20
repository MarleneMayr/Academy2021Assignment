using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Obstacle : MonoBehaviour
{
    public int colorIndex;

    void Start()
    {
        var color = ColorPalette.instance.Colors[colorIndex];
        GetComponent<SpriteRenderer>().color = color;
    }
}
