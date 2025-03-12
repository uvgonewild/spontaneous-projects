using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float timeInterval = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(timeInterval);

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
