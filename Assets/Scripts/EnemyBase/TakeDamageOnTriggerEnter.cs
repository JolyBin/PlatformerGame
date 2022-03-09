using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTriggerEnter : MonoBehaviour
{
    public AbstractHeals EnemyHeals;
    public bool DieOnEnyCollision;
    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.attachedRigidbody?.GetComponent<Bullet>();
        if (bullet)
        {
            EnemyHeals.TakeDamage(bullet.Damage);
        }
        if (DieOnEnyCollision && !other.isTrigger)
        {
            EnemyHeals.TakeDamage(10000);
        }
    }
}
