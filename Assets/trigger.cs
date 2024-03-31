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
            Instantiate(enviormentTrigger, new Vector3(-14.22471f, 11.2654f, 530f), Quaternion.identity);
        }
        else
        {
            Debug.Log("Other object entered trigger but does not have the 'triggers' tag.");
        }
    }
}
