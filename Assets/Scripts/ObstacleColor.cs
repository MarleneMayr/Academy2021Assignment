using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObstacleColor : MonoBehaviour
{
    public int colorIndex;

    void Start()
    {
        var color = ColorPalette.instance.Colors[colorIndex];
        GetComponent<SpriteRenderer>().color = color;
    }
}
