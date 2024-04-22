using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed

    void Update()
    {
        Debug.Log("Update method called."); // Debug statement

        // Check for left and right movement based on the horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0)
        {
            Debug.Log("Left input detected."); // Debug statement
                                               // Move the boat left
            MoveBoat(-1);
        }
        else if (horizontalInput > 0)
        {
            Debug.Log("Right input detected."); // Debug statement
                                                // Move the boat right
            MoveBoat(1);
        }
    }


    // Function to move the boat horizontally
    void MoveBoat(int direction)
    {
        // Calculate the movement amount based on direction and speed
        float movement = direction * moveSpeed * Time.deltaTime;

        // Apply the movement to the boat's position
        transform.Translate(Vector3.right * movement);
    }
}
