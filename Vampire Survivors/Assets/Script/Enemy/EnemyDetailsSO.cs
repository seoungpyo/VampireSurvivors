using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetailsSO_", menuName = "Scriptable Object/Enemy/EnemyDetails")]
public class EnemyDetailsSO : ScriptableObject
{
    #region Header MOVEMENT
    [Space(10)]
    [Header("MOVEMENT")]
    #endregion
    public float moveSpeed;

    #region Header COMBAT
    [Space(10)]
    [Header("COMBAT")]
    #endregion
    public float hitCount;

    public int maxDamage;
    public int minDamage;

    #region Header ANIMATION
    [Space(10)]
    [Header("ANIMATION")]
    #endregion
    public float maxAnimationSize;
    public float minAnimationSize;
    public float maxAnimationSpeed;
    public float minAnimationSpeed;
}