using UnityEngine;

public class AutoFireController : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile
    public Transform firePoint; // Transform representing the point where projectiles will be fired from
    public float fireRate = 0.5f; // Rate of fire (projectiles per second)
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
            // Fire projectiles
            FireProjectile(); // Call FireProjectile here

            // Find all enemy boats in the scene
            GameObject[] enemyBoats = GameObject.FindGameObjectsWithTag(enemyBoatTag);

            // Fire at each enemy boat
            foreach (GameObject enemyBoat in enemyBoats)
            {
                FireAtEnemy(enemyBoat.transform);
            }

            // Update the next allowed fire time
            nextFireTime = Time.time + 1f / fireRate;
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
    }

    private void FireProjectile()
    {
        Debug.Log("Firing projectile"); // Add debug log
                                        // Instantiate the projectile prefab at the fire point
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

}
