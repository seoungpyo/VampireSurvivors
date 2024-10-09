using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class UIController : SingletonMonobehavior<UIController>
{
    public Slider expLevelSlider;
    public TMP_Text expLevelText;

    protected override void Awake()
    {
        base.Awake();
    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLevel)
    {
        expLevelSlider.maxValue = levelExp;
        expLevelSlider.value = currentExp;

        expLevelText.text = "LEVEL : " + currentLevel.ToString();
    }
}
