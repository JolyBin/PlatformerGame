using UnityEngine;

namespace Loot
{
    public class LootHeal : MonoBehaviour
    {
		public int HealthValue = 1;

		private void OnTriggerEnter(Collider other)
		{
			if (other.attachedRigidbody.GetComponent<PlayerHealth>())
			{
				other.attachedRigidbody?.GetComponent<PlayerHealth>()?.AddHealth(HealthValue);
				Object.Destroy(base.gameObject);
			}
		}
	}
}
