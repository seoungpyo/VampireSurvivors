using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetailsSO_", menuName = "Scriptable Object/Enemy/EnemyDetails")]
public class EnemyDetailsSO : ScriptableObject
{
    #region Header ENEMY BASE DETAILS
    [Space(10)]
    [Header("BASE ENEMY DETAILS")]
    #endregion
    public string enemyName;

    #region Header MOVEMENT
    [Space(10)]
    [Header("MOVEMENT")]
    #endregion
    public float moveSpeed;

    #region Header COMBAT
    [Space(10)]
    [Header("COMBAT")]
    #endregion
    public float hitWaitTime = 1f;
    public float knockBackTime = 0.5f;

    public int maxDamage;
    public int minDamage;

    #region Header HEALTH
    [Space(10)]
    [Header("HEALTH")]
    #endregion
    public float health;

    #region Header ANIMATION
    [Space(10)]
    [Header("ANIMATION")]
    #endregion
    public float maxAnimationSize;
    public float minAnimationSize;
    public float animationSpeed = 0.5f;
}