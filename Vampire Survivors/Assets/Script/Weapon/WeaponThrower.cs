using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrower : Weapon
{
    public EnemyDamager enemyDamager;
    private float throwCounter;

    private void Start()
    {
        SetStats();
    }

    private void Update()
    {
        if(stateUpdated)
        {
            stateUpdated = false;
            SetStats();
        }

        throwCounter -= Time.deltaTime;

        if(throwCounter <= 0)
        {
            throwCounter = state[weaponLevel].timeBetweenAttacks;

            for(int i =0; i < state[weaponLevel].amount; i++)
            {
                Instantiate(enemyDamager, enemyDamager.transform.position, enemyDamager.transform.rotation).gameObject.SetActive(true);
            }

            SFXManager.Instance.PlaySFXPitched(4);
        }
    }

    void SetStats()
    {
        enemyDamager.damageAmount = state[weaponLevel].damage;
        enemyDamager.lifeTime = state[weaponLevel].duration;

        enemyDamager.transform.localScale = Vector3.one * state[weaponLevel].range;

        throwCounter = 0f; 
    }

}
