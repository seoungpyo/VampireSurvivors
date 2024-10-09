using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponState> state;
    public int weaponLevel;
}

[System.Serializable]
public class WeaponState
{
    public float speed;
    public float damage;
    public float range;
    public float timeBetweenAttacks;
    public float amount;
    public float duration;
}
