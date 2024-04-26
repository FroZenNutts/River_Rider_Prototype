using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Speed of the projectile

    void Start()
    {
        // Set the velocity of the projectile in the forward direction
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the projectile collides with an enemy boat
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy boat
            Destroy(collision.gameObject);

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}

