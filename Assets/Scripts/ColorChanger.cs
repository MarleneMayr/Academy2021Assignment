using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ColorEvent : UnityEvent<Color>
{
}

public class ColorChanger : MonoBehaviour
{
    public static ColorEvent colorChanged = new ColorEvent();
    [SerializeField] private ColorPalette palette;
    private int index;

    private void Start()
    {
        var color = palette.Colors[SetRandomNewIndex()];
        colorChanged?.Invoke(color);
    }

    private void Update()
    {
        // new color on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            var color = palette.Colors[SetRandomNewIndex()];
            colorChanged?.Invoke(color);
        }
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
