using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public EnemyDamager enemyDamager;
    public Projectile projectile;

    private float shotCounter;

    public float weaponRange;
    public LayerMask enemyLayer;

    private void Start()
    {
        SetStats();
    }

    private void Update()
    {
        if (stateUpdated)
        {
            stateUpdated = false;
            SetStats();
        }

        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            shotCounter = state[weaponLevel].timeBetweenAttacks;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange * state[weaponLevel].range, enemyLayer);
            if(enemies.Length >0)
            {
                for(int i =0; i < state[weaponLevel].amount; i++)
                {
                    Vector3 targetPosition = enemies[Random.Range(0, enemies.Length)].transform.position;

                    Vector3 direction = targetPosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    angle -= 90;
                    projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    Instantiate(projectile, projectile.transform.position, projectile.transform.rotation).gameObject.SetActive(true);
                }
                SFXManager.Instance.PlaySFXPitched(6);
            }
        }
    }

    void SetStats()
    {
        enemyDamager.damageAmount = state[weaponLevel].damage;
        enemyDamager.lifeTime = state[weaponLevel].duration;

        enemyDamager.transform.localScale = Vector3.one * state[weaponLevel].range;

        shotCounter = 0;

        projectile.moveSpeed = state[weaponLevel].speed;
    }
}
