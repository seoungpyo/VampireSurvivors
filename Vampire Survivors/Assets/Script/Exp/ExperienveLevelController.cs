using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienveLevelController : SingletonMonobehavior<ExperienveLevelController>
{
    [HideInInspector] public int currentExperience;
    public List<Weapon> weaponToUpdgrade;
    public List<int> expLevels;
    public int currentLevel = 1;
    public ExpPickup pickup;

    private int levelCount = 100;

    private void Start()
    {
        while (expLevels.Count < expLevels.Count)
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1.1f));
        }    
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;

        if(currentExperience >= expLevels[currentLevel])
        {
            LevelUp();
        }

        UIController.Instance.UpdateExperience(currentExperience, expLevels[currentLevel], currentLevel);

        SFXManager.Instance.PlaySFXPitched(2);
    }

    public void SpawnExp(Vector3 position, int expValue)
    {
        Instantiate(pickup, position, Quaternion.identity).expValue = expValue;
    }
    
    private void LevelUp()
    {
        currentExperience -= expLevels[currentLevel];
        currentLevel++;

        if(currentLevel >= expLevels.Count)
        {
            currentLevel = expLevels.Count - 1;
        }

        //PlayerController.instance.activeWeapon.LevelUp();

        UIController.Instance.levelUpPanel.SetActive(true);

        Time.timeScale = 0f;

        weaponToUpdgrade.Clear();

        List<Weapon> availableWeapons = new List<Weapon>();
        availableWeapons.AddRange(PlayerController.instance.assignedWeapons);

        if(availableWeapons.Count > 0)
        {
            int selected = Random.Range(0, availableWeapons.Count);
            weaponToUpdgrade.Add(availableWeapons[selected]);
            availableWeapons.RemoveAt(selected);
        }

        if (PlayerController.instance.assignedWeapons.Count + PlayerController.instance.fullyLevelledWeapon.Count < PlayerController.instance.maxWeapons)
        {
            availableWeapons.AddRange(PlayerController.instance.unassignedWeapons);
        }

        for(int i = weaponToUpdgrade.Count; i < 3; i++)
        {
            if(availableWeapons.Count > 0)
            {
                int selected = Random.Range(0, availableWeapons.Count);
                weaponToUpdgrade.Add(availableWeapons[selected]);
                availableWeapons.RemoveAt(selected);
            }
        }

        for(int i =0; i < weaponToUpdgrade.Count; i++)
        {
            UIController.Instance.levelUpButtons[i].UpdateButtonDisplay(weaponToUpdgrade[i]);
        }


        for(int i= 0; i < UIController.Instance.levelUpButtons.Length; i++)
        {
            if (i < weaponToUpdgrade.Count)
            {
                UIController.Instance.levelUpButtons[i].gameObject.SetActive(true);
            }
            else
            {
                UIController.Instance.levelUpButtons[i].gameObject.SetActive(false);
            }
        }

        PlayerStatController.Instance.UpgradeDisplay();
    }
}
