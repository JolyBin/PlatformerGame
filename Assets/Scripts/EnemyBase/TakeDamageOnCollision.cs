// TakeDamageOnCollision
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
	public EnemyHealth EnemyHeals;

	public bool DieOnEnyCollision;

	private void OnCollisionEnter(Collision collision)
	{
		Bullet component = collision.transform.GetComponent<Bullet>();
		if ((bool)collision.transform.GetComponent<Bullet>())
		{
			EnemyHeals.TakeDamage(component.Damage);
		}
		if (DieOnEnyCollision)
		{
			EnemyHeals.TakeDamage(10000);
		}
	}
}
