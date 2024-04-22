using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float moveSpeedControl = 5f; // Adjust the speed as needed

    void Update()
    {
        Debug.Log("Update method is called."); // Debug statement

        // Check for A and D key presses
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A key pressed."); // Debug statement
            // Move the boat left
            MoveBoatHorizontally(-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D key pressed."); // Debug statement
            // Move the boat right
            MoveBoatHorizontally(1);
        }
    }

    // Function to move the boat horizontally
    void MoveBoatHorizontally(int direction)
    {
        // Calculate the movement amount based on direction and speed
        float movement = direction * moveSpeedControl * Time.deltaTime;

        // Apply the movement to the boat's position
        transform.Translate(Vector3.right * movement);
    }
}
