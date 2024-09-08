using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEvent : MonoBehaviour
{
    public event Action<HealthEvent, HealthEventArgs> OnHealthChanged;

    public void CallHealthChangedEvent(int currentHealth,int damage)
    {
        OnHealthChanged?.Invoke(this, new HealthEventArgs() {currentHealth = currentHealth, damage = damage });
    }
}

public class HealthEventArgs : EventArgs
{
    public int currentHealth;
    public int damage;
}
