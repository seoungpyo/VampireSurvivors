using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public float speed  = 0.5f;
    public float minSize = 0.9f;
    public float maxSize = 1.1f;

    private float activeSize;

    private SpriteRenderer sprite;

    private void Start()
    {
        activeSize = maxSize;
        speed *= Random.Range(0.75f, 1.25f);

        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        sprite.transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one * activeSize, speed * Time.deltaTime);

        if(sprite.transform.localScale.x == maxSize)
        {
            activeSize = minSize;
        }
        else if(sprite.transform.localScale.x == minSize)
        {
            activeSize = maxSize;
        }
    }

}
