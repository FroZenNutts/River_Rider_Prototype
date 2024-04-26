using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float fireRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Start firing automatically every 2 seconds
        InvokeRepeating("Fire", 0f, fireRate);
    }

    void Fire()
    {
        // Create a new bullet instance
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Get the rigidbody component of the bullet
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // If the bullet has a rigidbody, apply force to move it forward
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody component.");
        }
    }
}
