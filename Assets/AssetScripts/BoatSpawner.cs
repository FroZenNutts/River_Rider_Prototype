using System.Collections;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public GameObject boatPrefab;
    public float spawnRange = 50f;
    public float moveSpeed = 5f;
    public Transform player;

    void Start()
    {
        SpawnBoats();
    }

    void SpawnBoats()
    {
        Vector3 playerPosition = player.position;
        for (int i = 0; i < 5; i++) // Spawn 5 boats
        {
            Vector3 randomPosition = playerPosition + Random.insideUnitSphere * spawnRange;
            randomPosition.y = 0f; // Ensure boats spawn at the same height as the river
            GameObject boat = Instantiate(boatPrefab, randomPosition, Quaternion.identity);
            MoveBoatTowardsPlayer(boat);
        }
    }

    void MoveBoatTowardsPlayer(GameObject boat)
    {
        Vector3 direction = (player.position - boat.transform.position).normalized;
        Rigidbody boatRigidbody = boat.GetComponent<Rigidbody>();
        boatRigidbody.velocity = direction * moveSpeed;
    }
}
