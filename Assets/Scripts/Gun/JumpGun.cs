using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
	public Rigidbody PlayerRigidbody;

	public float Speed;

	public Transform Spawn;

	public Armory CurrentGun;

	public float MaxCharge = 3f;

	private float _currentCharge;

	private bool _isCharged;

	public ChargeIcon ChargeIcon;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && _isCharged)
		{
			PlayerRigidbody.AddForce(-Spawn.forward * Speed, ForceMode.VelocityChange);
			CurrentGun.Guns[CurrentGun.CurrentGunIndex].Shoot();
			_isCharged = false;
			_currentCharge = 0f;
			ChargeIcon.StartCharge();
		}
		else if (_currentCharge < MaxCharge)
		{
			_currentCharge += Time.deltaTime;
			ChargeIcon.SetCharrgeValue(_currentCharge, MaxCharge);
		}
		else
		{
			_isCharged = true;
			ChargeIcon.StopCharge();
		}
	}
}
