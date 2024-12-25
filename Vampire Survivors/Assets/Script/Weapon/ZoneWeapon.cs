using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWeapon : Weapon
{
    public EnemyDamager enemyDamager;

    private float spawnTime;
    private float spawnCounter;

    private void Awake()
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

        spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0)
        {
            spawnCounter = spawnTime;

            Instantiate(enemyDamager, enemyDamager.transform.position, Quaternion.identity, transform).gameObject.SetActive(true);

            SFXManager.Instance.PlaySFXPitched(10);
        }
    }

    private void SetStats()
    {
        enemyDamager.damageAmount = state[weaponLevel].damage;
        enemyDamager.lifeTime = state[weaponLevel].duration;

        enemyDamager.timeBetweenDamage = state[weaponLevel].speed;

        enemyDamager.transform.localScale = Vector3.one * state[weaponLevel].range;

        spawnTime = state[weaponLevel].timeBetweenAttacks;

        spawnCounter = 0f;
    }
}
