using UnityEngine;

public class AutoFireController : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile
    public Transform firePoint; // Transform representing the point where projectiles will be fired from
    public float fireRate = 2f; // Rate of fire (projectiles per second)
    public string enemyBoatTag = "Enemy"; // Tag of the enemy boats
    private float nextFireTime; // Time of the next allowed fire

    private void Start()
    {
        nextFireTime = Time.time;
    }

    private void Update()
    {
        // Check if it's time to fire
        if (Time.time >= nextFireTime)
        {
            // Find all enemy boats in the scene
            GameObject[] enemyBoats = GameObject.FindGameObjectsWithTag(enemyBoatTag);

            // Debug print to verify if enemy boats are detected
            Debug.Log("Number of enemy boats detected: " + enemyBoats.Length);

            // Fire at the nearest enemy boat
            FireAtNearestEnemy(enemyBoats);

            // Update the next allowed fire time based on fire rate
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void FireAtNearestEnemy(GameObject[] enemyBoats)
    {
        float nearestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        // Find the nearest enemy boat
        foreach (GameObject enemyBoat in enemyBoats)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyBoat.transform.position);
            if (distanceToEnemy < nearestDistance)
            {
                nearestDistance = distanceToEnemy;
                nearestEnemy = enemyBoat.transform;
            }
        }

        // Debug print to verify if nearest enemy is found
        if (nearestEnemy != null)
        {
            Debug.Log("Firing at nearest enemy boat: " + nearestEnemy.name);
            FireAtEnemy(nearestEnemy);
        }
        else
        {
            Debug.Log("No enemy boats detected.");
        }
    }

    private void FireAtEnemy(Transform enemyTransform)
    {
        // Calculate direction to enemy
        Vector3 directionToEnemy = (enemyTransform.position - firePoint.position).normalized;

        // Rotate towards the enemy
        Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy, Vector3.up);
        firePoint.rotation = Quaternion.RotateTowards(firePoint.rotation, targetRotation, 180f);

        // Instantiate a projectile at the fire point
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Debug print to verify firing
        Debug.Log("Projectile fired at enemy boat: " + enemyTransform.name);
    }
}
