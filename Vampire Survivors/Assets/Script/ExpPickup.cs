using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expValue;
    public float moveSpeed;

    public float timeBetwwenChecks = 0.2f;
    private float checkCounter;

    private bool movingToPlayer = false;
    
    private Player player;

    private void Awake()
    {
        player = GameManager.Instance.player;
    }

    private void Update()
    {
        if (movingToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            checkCounter -= Time.deltaTime;
            if(checkCounter <= 0)
            {
                checkCounter = timeBetwwenChecks;

                if(Vector3.Distance(transform.position, player.transform.position)< Settings.pickUpRange)
                {
                    movingToPlayer = true;
                    moveSpeed += player.moveSpeed;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ExperienveLevelController.Instance.GetExp(expValue);

            Destroy(gameObject);
        }
    }
}
