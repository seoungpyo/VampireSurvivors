using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HealthEvent))]
[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject deathEffect;

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
    
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        CallHealthChangedEvent(damage);
    }

    public void SetStartingHealth(int startingHealth)
    {
        this.startingHealth = startingHealth;
        currentHealth = startingHealth;

        if(healthBar != null)
        {
            healthBar.maxValue = currentHealth;
            healthBar.value = currentHealth;
        }
    }

    public void UpgradeHealthAmount(int newHealthAmount, int oldHealthAmount)
    {
        this.startingHealth = newHealthAmount;
        currentHealth += newHealthAmount - oldHealthAmount;

        if (healthBar != null)
        {
            healthBar.maxValue = newHealthAmount;
            healthBar.value = currentHealth;

            Debug.Log("a" + healthBar.maxValue);
            Debug.Log("b" + healthBar.value);

        }

        CallHealthChangedEvent(0);
    }

    private void CallHealthChangedEvent(int damage)
    {
        healthEvent.CallHealthChangedEvent(currentHealth, damage);
    }

    public void PlayDeathEffect()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
    }
}
