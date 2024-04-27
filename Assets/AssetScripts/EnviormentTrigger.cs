using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviormentTrigger : MonoBehaviour
{
    public GameObject environmentSectionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("Trigger event detected");
            Vector3 position = new Vector3(0, 0, 211f);
            Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);
            Instantiate(environmentSectionPrefab, position, rotation);
        }
        else
        {
            Debug.Log("Other object entered trigger but does not have the 'Trigger' tag.");
        }
    }
}