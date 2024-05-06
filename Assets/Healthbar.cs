using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int maxHealth = 100; // Change this to your desired maximum health value

    // Reference to the game over panel script
    private GameOverpanel gameOverPanel;

    private void Start()
    {
        SetMaxHealth(maxHealth);

        // Find the GameOverPanel script component in the scene
        gameOverPanel = FindObjectOfType<GameOverpanel>();

        // Check if the game over panel was found
        if (gameOverPanel == null)
        {
            Debug.LogError("Game Over Panel not found in the scene!");
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        // Check if health is zero and show game over panel
        if (health <= 0 && gameOverPanel != null)
        {
            gameOverPanel.ShowGameOverPanel();
        }
    }
}

