using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractHeals : MonoBehaviour
{
    public int Health = 5;
    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;

    public bool IsGod;




    public virtual void TakeDamage(int damageValue)
    {
        if (!IsGod)
        {
            Health -= damageValue;
        }
        if (Health <= 0)
        {
            Die();
        }
        EventOnTakeDamage.Invoke();
    }

    public virtual void Die()
    {
        EventOnDie.Invoke();
    }

    public void SetValueGod(bool value)
    {
        IsGod = value;
    }
}
