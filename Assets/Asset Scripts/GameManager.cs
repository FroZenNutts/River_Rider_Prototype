

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance of the GameManager
    public static GameManager instance;

    // Game state
    private bool isGameOver = false;

    void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Ensure GameManager persists between scenes
        DontDestroyOnLoad(gameObject);
    }

    // Method to start the game
    public void StartGame()
    {
        isGameOver = false;
        // Add any initialization logic here for starting the game
        Debug.Log("Game Started");
    }

    // Method to end the game
    public void EndGame()
    {
        isGameOver = true;
        // Add any game over logic here, such as displaying a game over screen
        Debug.Log("Game Over");

        // Load the EndScene to effectively exit the game
        SceneManager.LoadScene("EndScene");
    }
}
