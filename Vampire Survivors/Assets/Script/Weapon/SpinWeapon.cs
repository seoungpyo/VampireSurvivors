using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : Weapon
{
    public float rotateSpeed;

    public Transform holder;
    public Transform fireballToSpawn;

    public float timeBetweenSpawn;
    private float spawnCounter;

    public EnemyDamager enemyDamager;

    private void Start()
    {
        SetState();

        UIController.Instance.levelUpButtons[0].UpdateButtonDisplay(this);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f,holder.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime * state[weaponLevel].speed));

        spawnCounter -= Time.deltaTime;

        if (spawnCounter <= 0)
        {
            spawnCounter = timeBetweenSpawn;

            for (int i = 0; i < state[weaponLevel].amount; i++)
            {
                float rot = (360f/state[weaponLevel].amount) * i;

                Instantiate(fireballToSpawn, fireballToSpawn.position, Quaternion.Euler(0, 0, rot), holder).gameObject.SetActive(true);
            }
        }

        if(stateUpdated)
        {
            stateUpdated = false;
            SetState();
        }
    }

    private void SetState()
    {
        enemyDamager.damageAmount = state[weaponLevel].damage;

        transform.localScale = Vector3.one * state[weaponLevel].range;

        timeBetweenSpawn = state[weaponLevel].timeBetweenAttacks;

        enemyDamager.lifeTime = state[weaponLevel].duration;

        spawnCounter = 0f;
    }

}
