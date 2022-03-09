using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorBariers : MonoBehaviour
{
    public GameObject Barier;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody?.GetComponent<PlayerHealth>())
        {
            Barier?.SetActive(true);
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
