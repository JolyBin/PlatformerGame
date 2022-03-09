using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
    public Vector3 LeftEuler = new Vector3(0f, -10f, 0f);
    public Vector3 RighthEuler = new Vector3(0f, -170f, 0f);

    public float RotationSpeed = 5f;

    Transform _playerTransforf;
    Vector3 _targetEuler;
    void Start()
    {
        _playerTransforf = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _playerTransforf.position.x)
        {
            _targetEuler = RighthEuler;
        }
        else
        {
            _targetEuler = LeftEuler;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }
}
