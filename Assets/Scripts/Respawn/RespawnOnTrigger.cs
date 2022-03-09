using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespawnOnTrigger : MonoBehaviour
{
    public Transform SpawnPosition;
    public UnityEvent EventsOnRespawn;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.attachedRigidbody?.GetComponent<PlayerHealth>();
        if (player)
        {
            player.transform.position = SpawnPosition.position;
            EventsOnRespawn.Invoke();
        }
    }
}
