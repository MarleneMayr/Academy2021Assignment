using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorChanger : MonoBehaviour
{
    public static UnityEvent<Color> colorChanged = new UnityEvent<Color>();
    [SerializeField] private ColorPalette palette;
    private int index;

    private void Start()
    {
        var color = palette.Colors[SetRandomNewIndex()];
        colorChanged?.Invoke(color);
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
}
