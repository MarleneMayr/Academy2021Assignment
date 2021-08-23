using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class AspectRatioChecker
{
    static AspectRatioChecker()
    {
        // register an event handler when the class is initialized
        EditorApplication.playModeStateChanged += CheckGameView;
    }

    private static void CheckGameView(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            float ratio = (float)Screen.width / (float)Screen.height;

            // portrait mode games assume a ratio < 1, e.g. 9:16 = 0.5625
            if (ratio < 1)
            {
                // Aspect ratio is portrait mode
                if (0.55 < ratio && ratio < 0.57)
                {
                    // Aspect ratio is in desired range, close to 9:16
                }
                else
                {
                    Debug.Log($"Please set the aspect ratio of the game view to 9:16.");
                }
            }
            else
            {
                Debug.LogWarning($"Wrong aspect ratio deteced. Please set the aspect ratio of the game view to 9:16.");
            }
        }
    }
}