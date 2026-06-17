using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform player;

    [Header("Platform Settings")]
    public GameObject[] platformPrefabs;
    public float platformLength = 12f;
    public int startPlatformCount = 6;
    public float spawnAheadDistance = 45f;
    public float deleteBehindDistance = 25f;

    [Header("Platform Position")]
    public float minX = -2f;
    public float maxX = 2f;

    [Header("Hazard Settings")]
    public GameObject[] hazardPrefabs;
    public float hazardSpawnChance = 0.7f;
    public int maxHazardsPerPlatform = 2;
    public float hazardY = 0.6f;

    private float nextSpawnZ = 12f;
    private List<GameObject> activePlatforms = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < startPlatformCount; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (player == null || GameManager.Instance == null || !GameManager.Instance.isGameStarted)
        {
            return;
        }

        while (nextSpawnZ < player.position.z + spawnAheadDistance)
        {
            SpawnPlatform();
        }

        DeleteOldPlatforms();
    }

    void SpawnPlatform()
    {
        if (platformPrefabs.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, platformPrefabs.Length);
        GameObject prefab = platformPrefabs[randomIndex];

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 0f, nextSpawnZ);

        GameObject newPlatform = Instantiate(prefab, spawnPosition, Quaternion.identity);
        activePlatforms.Add(newPlatform);

        SpawnHazardsOnPlatform(newPlatform, randomX, nextSpawnZ);

        nextSpawnZ += platformLength;
    }

    void SpawnHazardsOnPlatform(GameObject platform, float platformX, float platformZ)
    {
        if (hazardPrefabs.Length == 0)
        {
            return;
        }

        if (Random.value > hazardSpawnChance)
        {
            return;
        }

        int hazardCount = Random.Range(1, maxHazardsPerPlatform + 1);

        for (int i = 0; i < hazardCount; i++)
        {
            int hazardIndex = Random.Range(0, hazardPrefabs.Length);
            GameObject hazardPrefab = hazardPrefabs[hazardIndex];

            float randomX = platformX + Random.Range(-2.3f, 2.3f);
            float randomZ = platformZ + Random.Range(-4f, 4f);

            Vector3 hazardPosition = new Vector3(randomX, hazardY, randomZ);

            GameObject hazard = Instantiate(hazardPrefab, hazardPosition, Quaternion.identity);
            hazard.transform.SetParent(platform.transform);
        }
    }

    void DeleteOldPlatforms()
    {
        for (int i = activePlatforms.Count - 1; i >= 0; i--)
        {
            GameObject platform = activePlatforms[i];

            if (platform == null)
            {
                activePlatforms.RemoveAt(i);
                continue;
            }

            if (platform.transform.position.z < player.position.z - deleteBehindDistance)
            {
                activePlatforms.RemoveAt(i);
                Destroy(platform);
            }
        }
    }
}