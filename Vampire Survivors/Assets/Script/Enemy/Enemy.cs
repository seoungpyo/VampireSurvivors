using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Requrie Component
[RequireComponent(typeof(EnemyAnimation))]
[RequireComponent(typeof(MovementByVelocityEvent))]
[RequireComponent(typeof(MovementByVelocity))]
[RequireComponent(typeof(EnemyAnimation))]
#endregion

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [HideInInspector] public MovementByVelocity movementByVelocity;
    [HideInInspector] public MovementByVelocityEvent movementByVelocityEvent;
    [HideInInspector] public EnemyAnimation enemyAnimation;

    public EnemyDetailsSO enemyDetails;

    private void Awake()
    {
        movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }


}
