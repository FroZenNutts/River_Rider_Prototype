using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoatController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed

    void Update()
    {
        // Check for A and D key presses
        if (Input.GetKey(KeyCode.A))
        {
            // Move the boat left
            MoveBoat(-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
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