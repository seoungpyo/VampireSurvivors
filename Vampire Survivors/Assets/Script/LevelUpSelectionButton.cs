using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSelectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescText;
    public TMP_Text nameLevelText;
    public Image weaponIcon;

    private Weapon assignedWeapon;

    public void UpdateButtonDisplay(Weapon weapon)
    {
        upgradeDescText.text = weapon.state[weapon.weaponLevel].upgradeText;
        weaponIcon.sprite = weapon.icon;

        nameLevelText.text = weapon.name + " - Lvl " + weapon.weaponLevel;

        assignedWeapon = weapon;
    }

    public void SelectUpgrade()
    {
        if(assignedWeapon != null)
        {
            assignedWeapon.LevelUp();

            UIController.Instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
