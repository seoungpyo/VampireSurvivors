using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : SingletonMonobehavior<PlayerStatController>
{
    public List<PlayerStatValue> moveSpeed;
    public List<PlayerStatValue> health;
    public List<PlayerStatValue> pickupRange;
    public List<PlayerStatValue> maxWeapon;

    public int moveSpeedLevelCount;
    public int healthLevelCount;
    public int pickupRangeLevelCount;
    
    [HideInInspector] public int moveSpeedLevel;
    [HideInInspector] public int healthLevel;
    [HideInInspector] public int pickupRangeLevel;
    [HideInInspector] public int maxWeaponLevel;

    private Player player;

    private void Start()
    {
        for(int i = moveSpeed.Count -1; i< moveSpeedLevelCount; i++)
        {
            moveSpeed.Add(new PlayerStatValue(moveSpeed[i].cost + moveSpeed[1].cost, moveSpeed[i].value + (moveSpeed[1].value - moveSpeed[0].value)));
        }

        for (int i = health.Count - 1; i < healthLevelCount; i++)
        {
            health.Add(new PlayerStatValue(health[i].cost + health[1].cost, health[i].value + (health[1].value - health[0].value)));
        }

        for (int i = pickupRange.Count - 1; i < pickupRangeLevelCount; i++)
        {
            pickupRange.Add(new PlayerStatValue(pickupRange[i].cost + pickupRange[1].cost, pickupRange[i].value + (pickupRange[1].value - pickupRange[0].value)));
        }
    }

    protected override void  Awake()
    {
        base.Awake();

    }

    private void Update()
    {
        if (UIController.Instance.levelUpPanel.activeSelf)
        {
            UpgradeDisplay();
        }
    }

    public void UpgradeDisplay()
    {
        if (moveSpeedLevel < moveSpeed.Count - 1)
        {
            UIController.Instance.moveSpeedUpgradeDisplay.UpdateDisplay(moveSpeed[moveSpeedLevel + 1].cost,
                moveSpeed[moveSpeedLevel].value, moveSpeed[moveSpeedLevel + 1].value);
        }
        else
        {
            UIController.Instance.moveSpeedUpgradeDisplay.ShowMaxLevel();
        }


        if (healthLevel < health.Count - 1)
        {
            UIController.Instance.healthUpgradeDisplay.UpdateDisplay(health[healthLevel + 1].cost,
            health[healthLevel].value, health[healthLevel + 1].value);
        }
        else
        {
            UIController.Instance.healthUpgradeDisplay.ShowMaxLevel();
        }

        if (pickupRangeLevel < pickupRange.Count - 1)
        {
            UIController.Instance.pickupRangeUpgradeDisplay.UpdateDisplay(pickupRange[pickupRangeLevel + 1].cost,
            pickupRange[pickupRangeLevel].value, pickupRange[pickupRangeLevel + 1].value);
        }
        else
        {
            UIController.Instance.pickupRangeUpgradeDisplay.ShowMaxLevel();
        }
        if (maxWeaponLevel < maxWeapon.Count - 1)
        {
            UIController.Instance.maxWeaponUpgradeDisplay.UpdateDisplay(maxWeapon[maxWeaponLevel + 1].cost,
            maxWeapon[maxWeaponLevel].value, maxWeapon[maxWeaponLevel + 1].value);
        }
        else
        {
            UIController.Instance.maxWeaponUpgradeDisplay.ShowMaxLevel();
        }
    }

    public void PurchaseMoveSpeed()
    {
        moveSpeedLevel++;
        CoinController.Instance.SpendCoins(moveSpeed[moveSpeedLevel].cost);
        UpgradeDisplay();

        PlayerController.instance.moveSpeed = moveSpeed[moveSpeedLevel].value;
    }

    public void PurchaseHealth()
    {
        healthLevel++;
        CoinController.Instance.SpendCoins(health[healthLevel].cost);
        UpgradeDisplay();

        player = GameManager.Instance.player;
        player.GetComponent<Health>().UpgradeHealthAmount(Mathf.RoundToInt(health[healthLevel].value), Mathf.RoundToInt(health[healthLevel - 1].value));
    }

    public void PurchasePickupRange()
    {
        pickupRangeLevel++;
        CoinController.Instance.SpendCoins(pickupRange[pickupRangeLevel].cost);
        UpgradeDisplay();

        PlayerController.instance.pickupRange = pickupRange[pickupRangeLevel].value;
    }

    public void PurchaseMaxWeapon()
    {
        maxWeaponLevel++;
        CoinController.Instance.SpendCoins(maxWeapon[maxWeaponLevel].cost);
        UpgradeDisplay();

        PlayerController.instance.maxWeapons = Mathf.RoundToInt(maxWeapon[maxWeaponLevel].value);
    }
}

[System.Serializable]
public class PlayerStatValue
{
    public int cost;
    public float value;

    public PlayerStatValue(int newCost, float newValue)
    {
        cost = newCost;
        value = newValue;
    }
}
