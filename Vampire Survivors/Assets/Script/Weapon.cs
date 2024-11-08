using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponState> state;
    public int weaponLevel;
    public Sprite icon;

    [HideInInspector] public bool stateUpdated;

    public void LevelUp()
    {
        if(weaponLevel < state.Count - 1)
        {
            weaponLevel++;

            stateUpdated = true;
        }
    }
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
    public string upgradeText;
}
