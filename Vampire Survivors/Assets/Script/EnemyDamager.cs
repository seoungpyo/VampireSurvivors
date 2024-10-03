using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    public float lifeTime;
    public float growSpeed = 5f;
    private Vector3 targetSize;

    public bool shouldKnockBack;

    private void Start()
    {
        Destroy(gameObject, lifeTime);

        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0.2f)
        {
            targetSize = Vector3.zero;

            if(transform.localScale.x == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount, shouldKnockBack);
        }
    }
}
