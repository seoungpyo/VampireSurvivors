using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienveLevelController : SingletonMonobehavior<ExperienveLevelController>
{
    [HideInInspector] public int currentExperience;
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
    }
}
