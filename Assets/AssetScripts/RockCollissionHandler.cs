using UnityEngine;

public class RockCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player boat
        if (other.CompareTag("Player"))
        {
            // End the game when the player boat hits the rock
            EndGame();
        }
    }

    private void EndGame()
    {
        // Add your game-ending logic here
        Debug.Log("Game Over!"); // Placeholder for game-ending action
        // You can add more actions here like showing game over screen, stopping game mechanics, etc.
        // For example:
        // Time.timeScale = 0f; // Stop game time
        // GameManager.Instance.ShowGameOverScreen();
    }
}
