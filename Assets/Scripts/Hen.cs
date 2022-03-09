using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed = 3;
    public float TimeToReachSpeed = 1;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity) / TimeToReachSpeed;

        Rigidbody.AddForce(force);
    }
}
