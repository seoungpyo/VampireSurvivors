using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Transform target;
    private Enemy enemy;

    private float moveSpeed;
    private float health;
    private float hitWaitTime;
    private float hitTime;

    private float knockBackTime;
    private float knockBackCounter;

    public int expToGive;

    private MovementByVelocityEvent movementByVelocityEvent;
    private EnemyAnimation enemyAnimation;


    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        enemyAnimation = GetComponent<EnemyAnimation>();

        target = GameManager.Instance.player.transform;

        Initialize(enemy.enemyDetails);
    }

    private void Update()
    {
        if (target == null)
        {
            rigidBody2D.velocity = Vector2.zero;
            return;
        }

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
                collision.gameObject.GetComponent<Health>().TakeDamage(GetAttackDamage(enemy.enemyDetails));

                hitTime = Time.time;
            }
        }
    }

    public int GetAttackDamage(EnemyDetailsSO enemyDetails)
    {
        return Random.Range(enemyDetails.minDamage, enemyDetails.maxDamage);
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if(health <= 0)
        {
            Destroy(gameObject);

            ExperienveLevelController.Instance.SpawnExp(transform.position, expToGive);

            if(Random.value <= enemy.enemyDetails.coinDropRate)
            {
                CoinController.Instance.DropCoin(transform.position, enemy.enemyDetails.coinValue);
            }

            SFXManager.Instance.PlaySFXPitched(0);
        }
        else
        {
            SFXManager.Instance.PlaySFXPitched(1);
        }

        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position);
    }

    public void TakeDamage(float damageToTake, bool shouldKnockBack)
    {
        TakeDamage(damageToTake);

        if(shouldKnockBack)
        {
            knockBackCounter = knockBackTime;
        }
    }

    public void Initialize(EnemyDetailsSO enemyDetails)
    {
        moveSpeed = enemyDetails.moveSpeed;
        health = enemyDetails.health;
        hitWaitTime = enemyDetails.hitWaitTime;
        knockBackTime = enemyDetails.knockBackTime;
        expToGive = enemyDetails.expValue;
    }
}
