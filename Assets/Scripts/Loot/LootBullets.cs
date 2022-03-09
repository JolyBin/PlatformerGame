using UnityEngine;

namespace Loot
{
    public class LootBullets : MonoBehaviour
    {
		public int GunIndex = 1;

		public int NumberOfBullets = 30;

		private void OnTriggerEnter(Collider other)
		{
			Armory component = other.attachedRigidbody.GetComponent<Armory>();
			if ((bool)component)
			{
				component.AddBulltes(GunIndex, NumberOfBullets);
				Object.Destroy(base.gameObject);
			}
		}
	}
}
