using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienveLevelController : SingletonMonobehavior<ExperienveLevelController>
{
    public int currentExperience;

    protected override void Awake()
    {
        base.Awake();
    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;
    }
}
