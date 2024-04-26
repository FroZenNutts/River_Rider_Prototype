using UnityEngine;

public class EnemyBoatSpawner : MonoBehaviour
{
    public GameObject enemyBoatPrefab; // Prefab of the enemy boat
    public string playerBoatTag = "Player"; // Tag of the player boat
    public Vector3 spawnOffset = new Vector3(0f, 0f, 10f); // Offset from the player boat's position
    public Vector3 spawnAreaSize = new Vector3(15f, -8f, 130f); // Size of the area where enemy boats can be spawned
    public float spawnInterval = 5f; // Time interval between enemy boat spawns
    private float nextSpawnTime; // Time of the next enemy boat spawn

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // Find the player boat GameObject by its tag
            GameObject playerBoat = GameObject.FindWithTag(playerBoatTag);

            if (playerBoat != null)
            {
                // Calculate spawn position offset from the player boat's position
                Vector3 spawnPosition = playerBoat.transform.position + playerBoat.transform.forward * spawnOffset.z +
                                        new Vector3(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                                                    0f,
                                                    Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f));

                // Check if the spawn position is behind the player boat
                float dotProduct = Vector3.Dot(spawnPosition - playerBoat.transform.position, playerBoat.transform.forward);
                if (dotProduct < 0)
                {
                    // If spawn position is behind, adjust it to be ahead of the player boat
                    spawnPosition = playerBoat.transform.position + playerBoat.transform.forward * spawnOffset.z;
                }

                // Instantiate an enemy boat at the calculated spawn position
                GameObject enemyBoat = Instantiate(enemyBoatPrefab, spawnPosition, Quaternion.identity);

                // Rotate the enemy boat to face the player boat
                Vector3 directionToPlayer = (playerBoat.transform.position - enemyBoat.transform.position).normalized;
                enemyBoat.transform.rotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
            }
            else
            {
                Debug.LogError("Player boat not found! Make sure to tag the player boat GameObject with the specified tag.");
            }

            // Update the next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
