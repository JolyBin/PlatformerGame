using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject EffectPrefab;
    public int Damage = 1;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<AbstractHeals>())
        {
            Instantiate(EffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
