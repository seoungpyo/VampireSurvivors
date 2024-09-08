using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rigidBody2D;
    private Transform target;
    private float damage = 5f;

    public float hitWaitTime = 1f;
    private float hitCounter;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        if (target == null) return;

        rigidBody2D.velocity = (target.position - transform.position).normalized * moveSpeed;

        if (hitCounter > 0) hitCounter -= Time.deltaTime; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0)
        {
            if (collision.gameObject.GetComponent<PlayerHealthController>() != null)
            {
                collision.gameObject.GetComponent<PlayerHealthController>().TakeDamage(damage);

                hitCounter = hitWaitTime;
            }
        }
    }

}
