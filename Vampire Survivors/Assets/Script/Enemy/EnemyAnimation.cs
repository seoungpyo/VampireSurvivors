using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private float speed;
    private float minSize;
    private float maxSize;

    private float activeSize;

    private SpriteRenderer sprite;
    private Enemy enemy;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        Initalize();
    }

    public void AnimationProcess()
    {
        sprite.transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one * activeSize, speed * Time.deltaTime);

        if (sprite.transform.localScale.x == maxSize)
        {
            activeSize = minSize;
        }
        else if (sprite.transform.localScale.x == minSize)
        {
            activeSize = maxSize;
        }
    }

    private void Initalize()
    {
        maxSize = enemy.enemyDetails.maxAnimationSize;
        minSize = enemy.enemyDetails.minAnimationSize;

        activeSize = maxSize;

        speed *= enemy.enemyDetails.animationSpeed;
    }

}
