using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject enviormentTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("trigger"))
        {
            Debug.Log("Trigger event detected");
            Instantiate(enviormentTrigger, new Vector3(-44f, 1.21f, 400f), Quaternion.identity);
        }
        else
        {
            Debug.Log("Other object entered trigger but does not have the 'trigger' tag.");
        }
    }
}
