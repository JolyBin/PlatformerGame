using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocetHeals : AbstractHeals
{
    public GameObject EffectPrefab;
    public override void Die()
    {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
