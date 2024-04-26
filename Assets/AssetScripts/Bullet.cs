using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f; // Adjust damage as needed

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy object
            Destroy(collision.gameObject);
        }

        // Destroy the bullet regardless of what it collides with
        Destroy(gameObject);
    }
}
