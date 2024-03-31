using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteEnvironmentGenerator : MonoBehaviour
{
    public GameObject[] environmentSectionPrefabs; // Prefabs for different environment sections
    public Transform player; // Reference to the player's transform
    public float sectionLength = 10f; // Length of each environment section

    private float spawnZ = 0f; // Z-coordinate to spawn new sections

    // Start is called before the first frame update
    void Start()
    {
        // Spawn initial environment sections
        SpawnSection();
        SpawnSection();
    }

    // Update is called once per frame
    void Update()
    {
        // Check player's position to determine if new sections need to be spawned
        if (player.position.z - 100 > spawnZ)
        {
            SpawnSection();
        }
    }

    void SpawnSection()
    {
        // Instantiate a random environment section prefab
        GameObject sectionPrefab = environmentSectionPrefabs[Random.Range(0, environmentSectionPrefabs.Length)];
        GameObject newSection = Instantiate(sectionPrefab, transform.position + Vector3.forward * spawnZ, Quaternion.identity);

        // Update spawnZ for the next section
        spawnZ += sectionLength;
    }
}
