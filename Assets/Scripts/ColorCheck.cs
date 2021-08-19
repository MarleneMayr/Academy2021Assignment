using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class ColorCheck : MonoBehaviour
{
    public static UnityEvent<Color> colorChanged = new UnityEvent<Color>();

    [SerializeField] private ColorPalette palette;
    private int index;
    private Player player;
    public Color currentColor => palette.Colors[index];

    private void Start()
    {
        player = GetComponent<Player>();
        var color = palette.Colors[SetRandomNewIndex()];
        player.SetColor(color);
    }

    private int SetRandomNewIndex()
    {
        // find a random index that is not the current one
        int newIndex = Random.Range(0, palette.Colors.Length);
        while (newIndex == index)
        {
            newIndex = Random.Range(0, palette.Colors.Length);
        }
        index = newIndex;
        return index;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ColorSwitch")
        {
            Destroy(other.gameObject);
            var color = palette.Colors[SetRandomNewIndex()];
            player.SetColor(color);
        }
    }
}
