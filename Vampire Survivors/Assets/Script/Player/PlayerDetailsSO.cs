using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDetails_", menuName = "Scriptable Object/Player/PlayerDetails")]
public class PlayerDetailsSO : ScriptableObject
{
    #region Header REFERENCE OBJECT;
    [Space(10)]
    [Header("PLAYER OBJECT")]
    #endregion
    public GameObject playerPrefab;

    #region Header MOVEMENT
    [Space(10)]
    [Header("MOVEMENT")]
    #endregion
    public float moveSpeed;

    #region Header HEALTH
    [Space(10)]
    [Header("HEALTH")]
    #endregion
    public int HealthAmount;

    #region Header SPRITE
    [Space(10)]
    [Header("SPRITE")]
    #endregion
    public Sprite sprite;
}
