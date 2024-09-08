using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HealthEvent))]
[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    private int startingHealth;
    private int currentHealth;

    private Enemy enemy; 
    private HealthEvent healthEvent;

    private void Awake()
    {
        healthEvent = GetComponent<HealthEvent>();
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();

        CallHealthChangedEvent(0);
    
        if(enemy != null)
        {

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        CallHealthChangedEvent(damage);
    }

    public void SetStartingHealth(int startingHealth)
    {
        this.startingHealth = startingHealth;
        currentHealth = startingHealth;
    }

    private void CallHealthChangedEvent(int damage)
    {
        healthEvent.CallHealthChangedEvent(currentHealth, damage);
    }
}
