using UnityEngine;

public class CleanUpItem : MonoBehaviour
{
    private readonly float threshold = -5;

    private void Update()
    {
        // destroy item when it drops below the screen
        if (Camera.main.WorldToScreenPoint(transform.position).y < threshold)
        {
            Destroy(gameObject);
        }
    }
}
