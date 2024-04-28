using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] spawnPoints;
    public float minInterval = 1f;
    public float maxInterval = 3f;

    private void Start()
    { 
        // Start spawning obstacles after a delay
        InvokeRepeating("SpawnObstacles", Random.Range(minInterval, maxInterval), Random.Range(minInterval, maxInterval));
    }

    private void SpawnObstacles()
    {
        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        Instantiate(obstaclePrefab, spawnPoint.position, randomRotation);
    }
}