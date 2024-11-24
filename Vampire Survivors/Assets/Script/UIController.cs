using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : SingletonMonobehavior<UIController>
{
    public Slider expLevelSlider;
    public TMP_Text expLevelText;
    public TMP_Text coinText;

    public LevelUpSelectionButton[] levelUpButtons;
    public GameObject levelUpPanel;

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

    public void SkipLevelUp()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpdateCoins()
    {
        coinText.text = "COins: " + CoinController.Instance.currentCoins;
    }
}
