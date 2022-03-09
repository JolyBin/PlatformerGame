using System;
using UnityEngine;

namespace EnemyBase
{
	public class MakeDamageOnTrigger : MonoBehaviour
	{
		public int DamageValue = 1;

		private void OnTriggerEnter(Collider other)
		{
			PlayerHealth playerHealth = other.attachedRigidbody?.GetComponent<PlayerHealth>();
			if ((bool)playerHealth)
			{
				playerHealth.TakeDamage(DamageValue);
			}
		}
	}
}