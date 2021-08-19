using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float followThreshold = 1f;
    [SerializeField] private Transform player;

    private void Update()
    {
        if (player == null) return;
        if (player.position.y > (transform.position.y + followThreshold))
        {
            // add the difference the camera is missing from the threshold
            var diff = player.position.y - followThreshold;
            transform.position = new Vector3(transform.position.x, diff, transform.position.z);
        }
    }
}
