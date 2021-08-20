using System;
using UnityEngine;

enum ItemType
{
    Star,
    ColorSwitch,
    Obstacle
}

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float spawnDistance;

    [Header("Item Prefabs")]
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private GameObject colorSwitchPrefab;
    [SerializeField] private GameObject[] obstaclePrefabs;

    private ItemType lastSpawned;
    private Vector3 playerReferencePos;

    private void Start()
    {
        // stop spawning at player death
        Player.playerDied.AddListener((player, message) => Destroy(gameObject));

        playerReferencePos = player.position;
        SpawnItem();
    }

    private void Update()
    {
        // spawn items in relation to "distance travelled"
        if (player.position.y > playerReferencePos.y + spawnDistance)
        {
            playerReferencePos = player.position;
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        var type = GetRandomType();
        lastSpawned = type;
        // spawn the items at the position of the spawner
        switch (type)
        {
            case ItemType.Star:
                Instantiate(starPrefab, transform.position, Quaternion.identity);
                break;
            case ItemType.ColorSwitch:
                Instantiate(colorSwitchPrefab, transform.position, Quaternion.identity);
                break;
            case ItemType.Obstacle:
                var obstacle = Instantiate(GetRandomObstaclePrefab(), transform.position, Quaternion.identity);
                // 50 % chance to flip the Obstacle horizontally
                if (UnityEngine.Random.value > 0.5)
                {
                    obstacle.transform.rotation = Quaternion.AngleAxis(180f, Vector3.up);
                }
                break;
        }
    }

    private ItemType GetRandomType()
    {
        var max = Enum.GetValues(typeof(ItemType)).Length;
        var rand = (ItemType)UnityEngine.Random.Range(0, max);
        // do not allow repetition unless type is Obstacle
        while (rand != ItemType.Obstacle && rand == lastSpawned)
        {
            rand = (ItemType)UnityEngine.Random.Range(0, max);
        }
        return rand;
    }

    private GameObject GetRandomObstaclePrefab()
    {
        var rand = UnityEngine.Random.Range(0, obstaclePrefabs.Length);
        return obstaclePrefabs[rand];
    }
}
