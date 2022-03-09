using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : AbstractHeals
{
    public int MaxHealth = 7;
    public HealthUI HealthUI;
    public bool Invulnerable = false;  

    public AudioSource AddHealthSound;
    

    public void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }
    public void AddHealth(int healthValue)
    {
        Health = Health + healthValue > MaxHealth ? MaxHealth : Health + healthValue;
        AddHealthSound.Play();
        HealthUI.DisplayHealth(Health);
    }

    public override void TakeDamage(int damageValue)
    {
        if (!Invulnerable)
        {
            base.TakeDamage(damageValue);
            Invulnerable = true;
            Invoke("StopInvulnerable", 1);
            HealthUI.DisplayHealth(Health);
        }
    }

    void StopInvulnerable()
    {
        Invulnerable = false;
    }
}
