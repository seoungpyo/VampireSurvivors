using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : SingletonMonobehavior<UIController>
{
    [Space]
    public Slider expLevelSlider;
    public TMP_Text expLevelText;
    public TMP_Text coinText;
    public TMP_Text timeText;

    [Space]
    public LevelUpSelectionButton[] levelUpButtons;
    public GameObject levelUpPanel;

    [Space]
    public PlayerStatUpgradeDisplay moveSpeedUpgradeDisplay;
    public PlayerStatUpgradeDisplay healthUpgradeDisplay;
    public PlayerStatUpgradeDisplay pickupRangeUpgradeDisplay;
    public PlayerStatUpgradeDisplay maxWeaponUpgradeDisplay;

    [Space]
    public GameObject levelEndScreen;
    public TMP_Text endTimeText;

    [Space]
    public GameObject pauseScreen;

    private string mainMenuName = "MainMenu";

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
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

    public void PurchaseMoveSpeed()
    {
        PlayerStatController.Instance.PurchaseMoveSpeed();
        SkipLevelUp();
    }

    public void PurchaseHealth()
    {
        PlayerStatController.Instance.PurchaseHealth();
        SkipLevelUp();
    }

    public void PurchasePickupRange()
    {
        PlayerStatController.Instance.PurchasePickupRange();
        SkipLevelUp();
    }

    public void PurchaseMaxWeapon()
    {
        PlayerStatController.Instance.PurchaseMaxWeapon();
        SkipLevelUp();
    }

    public void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60f);
        float seconds = Mathf.FloorToInt(time % 60f);

        timeText.text = "Time : " + minutes.ToString("0") + ":" + seconds.ToString("00");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseUnpause()
    {
        if (!pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            if (!levelUpPanel.activeSelf && !levelEndScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}
