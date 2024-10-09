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

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f,holder.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime));

        spawnCounter -= Time.deltaTime;

        if (spawnCounter <= 0)
        {
            spawnCounter = timeBetweenSpawn;

            Instantiate(fireballToSpawn, fireballToSpawn.position, fireballToSpawn.rotation, holder).gameObject.SetActive(true);
        }
    }
}
