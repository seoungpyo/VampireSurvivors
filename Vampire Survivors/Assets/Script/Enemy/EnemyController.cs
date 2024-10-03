using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rigidBody2D;
    private Transform target;
    private int damage = 5;

    public float hitWaitTime = 1f;
    private float hitTime;
    private Enemy enemy;

    public float health = 5f;

    public float knockBackTime = 0.5f;
    private float knockBackCounter;

    private MovementByVelocityEvent movementByVelocityEvent;
    private EnemyAnimation enemyAnimation;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        enemyAnimation = GetComponent<EnemyAnimation>();

        target = GameManager.Instance.player.transform;
    }

    private void Update()
    {
        if(knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;

            if (moveSpeed > 0)
            {
                moveSpeed -= moveSpeed*2f;
            }

            if(knockBackCounter <= 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed * 0.5f);
            }
        }

        MovementProcess();

        enemyAnimation.AnimationProcess();
        
    }

    private void MovementProcess()
    {
        if (target == null) return;

        Vector2 moveDir = (target.position - transform.position).normalized;

        movementByVelocityEvent.CallMovementToVelocityEvent(moveDir, moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Time.time > hitTime + hitWaitTime)
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);

                hitTime = Time.time;
            }
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damageToTake, bool shouldKnockBack)
    {
        TakeDamage(damageToTake);

        if(shouldKnockBack)
        {
            knockBackCounter = knockBackTime;
        }
    }
}
