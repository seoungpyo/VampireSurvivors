using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    public float lifeTime;
    public float growSpeed = 5f;

    public bool shouldKnockBack;
    public bool destroyParent;
    public bool damageOverTime;
    public float timeBetweenDamage;

    private Vector3 targetSize;
    private float damageCounter;
    private List<EnemyController> enemiesInRange = new List<EnemyController>();

    public bool destroyOnImpact;

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

                if (destroyParent)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }

        if (damageOverTime)
        {
            damageCounter -= Time.deltaTime;

            if(damageCounter <= 0)
            {
                damageCounter = timeBetweenDamage;

                for (int i = 0; i < enemiesInRange.Count; i++)
                {
                    if (enemiesInRange[i] != null)
                    {
                        enemiesInRange[i].TakeDamage(damageAmount, shouldKnockBack);
                    }
                    else
                    {
                        enemiesInRange.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!damageOverTime)
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<EnemyController>().TakeDamage(damageAmount, shouldKnockBack);

                if (destroyOnImpact)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if(collision.tag == "Enemy")
            {
                enemiesInRange.Add(collision.GetComponent<EnemyController>());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(damageOverTime)
        {
            if(collision.tag == "Enemy")
            {
                enemiesInRange.Remove(collision.GetComponent<EnemyController>());
            }
        }
    }
    
}
