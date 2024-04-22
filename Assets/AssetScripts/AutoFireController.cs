using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFireController : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile to be fired
    public float fireRate = 1f; // Rate of fire in shots per second
    private float nextFireTime; // Time of the next allowed shot
    private int shotsFired; // Number of shots fired
    private bool isFiring; // Flag to track if currently firing

    private void Start()
    {
        // Start firing after a random delay between 0 and 10 seconds
        float randomDelay = Random.Range(0f, 10f);
        Invoke("StartFiring", randomDelay);
    }

    private void StartFiring()
    {
        isFiring = true;
    }

    private void Update()
    {
        if (isFiring)
        {
            // Check if it's time to fire
            if (Time.time >= nextFireTime)
            {
                // Fire projectile
                FireProjectile();

                // Update shots fired
                shotsFired++;

                // Check if all shots have been fired
                if (shotsFired >= 3)
                {
                    isFiring = false; // Stop firing
                }
                else
                {
                    // Calculate time for the next shot
                    nextFireTime = Time.time + 1f / fireRate;
                }
            }
        }
    }

    private void FireProjectile()
    {
        // Instantiate the projectile at the current position and rotation of this GameObject
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
