using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region RequireComponent
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(HealthEvent))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(MovementByVelocity))]
[RequireComponent(typeof(MovementByVelocityEvent))]
[RequireComponent(typeof(Idle))]
[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
#endregion

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    public PlayerDetailsSO playerDetails;

    [HideInInspector] public int healthAmount;
    [HideInInspector] public float moveSpeed;
    [HideInInspector] public SpriteRenderer sprite;
    [HideInInspector] public HealthEvent healthEvent;
    [HideInInspector] public Health health;
    [HideInInspector] public PlayerController playerController;
    [HideInInspector] public MovementByVelocity movementByVelocity;
    [HideInInspector] public MovementByVelocityEvent movementByVelocityEvent;
    [HideInInspector] public Idle idle;
    [HideInInspector] public IdleEvent idleEvent;
    [HideInInspector] public Animator animator;

    private void Awake()
    {
        healthEvent = GetComponent<HealthEvent>();
        health = GetComponent<Health>();
        playerController = GetComponent<PlayerController>();
        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        idleEvent = GetComponent<IdleEvent>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        idleEvent = GetComponent<IdleEvent>();

        Initalize();
    }

    private void OnEnable()
    {
        healthEvent.OnHealthChanged += HealthEvent_OnHealthChanged;
    }

    private void OnDisable()
    {
        healthEvent.OnHealthChanged -= HealthEvent_OnHealthChanged;
    }

    public void Initalize()
    {
        SetPlayerHealth();
    }

    private void HealthEvent_OnHealthChanged(HealthEvent healthEvent, HealthEventArgs healthEvenArgs)
    {
        Debug.Log("HealthAmount : " + healthEvenArgs.currentHealth);

        if(healthEvenArgs.currentHealth <= 0)
        {
            Destroy(gameObject);

            LevelManager.Instance.EndLevel();

            health.PlayDeathEffect();

            SFXManager.Instance.PlaySFX(3);
        }
    }

    private void SetPlayerHealth()
    {
        health.SetStartingHealth(playerDetails.HealthAmount);
        //health.SetStartingHealth(Mathf.RoundToInt(PlayerStatController.Instance.health[0].value));
    }
}
