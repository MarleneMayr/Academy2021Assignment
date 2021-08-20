using UnityEngine;

public class ColorPalette : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    public Color[] Colors => colors;
    public static ColorPalette instance;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int GetRandomIndex()
    {
        return Random.Range(0, colors.Length);
    }

    public int GetRandomNewIndex(int current)
    {
        // find a random index that is not the current index
        var newIndex = Random.Range(0, colors.Length);
        while (newIndex == current)
        {
            newIndex = Random.Range(0, colors.Length);
        }
        return newIndex;
    }
}
