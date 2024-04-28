using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Healthbar healthBar;
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // This method should be called when the player takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Ensure health doesn't go below 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            GameOverPanel.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rocks"))
        {
            TakeDamage(20);
           
        }
    }
}