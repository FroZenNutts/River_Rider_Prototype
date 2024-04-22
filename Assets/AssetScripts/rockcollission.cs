using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockcollission : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            // Call the EndGame method of the GameManager
            GameManager.instance.EndGame();
        }
    }
}
