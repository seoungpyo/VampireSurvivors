using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class CloseAttackWeapon : Weapon
{
    public EnemyDamager enemyDamager;

    private float attackCounter;
    private float direction;

    private void Start()
    {
        SetState();    
    }

    private void Update()
    {
        if (stateUpdated)
        {
            stateUpdated = false;

            SetState();
        }

        attackCounter -= Time.deltaTime;

        if (attackCounter <= 0)
        {
            attackCounter = state[weaponLevel].timeBetweenAttacks;

            direction = Input.GetAxisRaw("Horizontal");

            if (direction != 0)
            {
                if (direction > 0)
                {
                    enemyDamager.transform.rotation = Quaternion.identity;
                }
                else
                {
                    enemyDamager.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }
            }

            Instantiate(enemyDamager, enemyDamager.transform.position, enemyDamager.transform.rotation).gameObject.SetActive(true);

            for(int i =1; i < state[weaponLevel].amount; i++)
            {
                float rot = (360f/ state[weaponLevel].amount) * i;

                Instantiate(enemyDamager, enemyDamager.transform.position, 
                    Quaternion.Euler(0f, 0f, enemyDamager.transform.rotation.eulerAngles.z + rot), transform).gameObject.SetActive(true);
            }

            SFXManager.Instance.PlaySFXPitched(9);
        }
    }

    void SetState()
    {
        enemyDamager.damageAmount = state[weaponLevel].damage;
        enemyDamager.lifeTime = state[weaponLevel].duration;

        enemyDamager.transform.localScale = Vector3.one * state[weaponLevel].range;

        attackCounter = 0f;
    }
}
