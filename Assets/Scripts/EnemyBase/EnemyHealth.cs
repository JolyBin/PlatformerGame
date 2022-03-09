// EnemyHealth
using UnityEngine;

public class EnemyHealth : AbstractHeals
{
    public override void Die()
    {
        base.Die();
        Destroy(gameObject, 0.2f);
    }
}
