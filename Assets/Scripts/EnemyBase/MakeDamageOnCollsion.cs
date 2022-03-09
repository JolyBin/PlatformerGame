using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollsion : MonoBehaviour
{
    public int DamageValue = 1;
    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth ph = collision.transform.GetComponent<PlayerHealth>();
        if (ph)
        {
            ph.TakeDamage(DamageValue);
        }
    }
}
