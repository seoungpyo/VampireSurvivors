using UnityEngine;
using UnityEngine.Serialization;

public class CoinPickUp : MonoBehaviour
{
    public int coinAmount = 1;
    public float moveSpeed;

    private bool movingToPlayer = false;
    public float timeBetweenChecks = 0.2f;
    private float checkCounter;

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
            if (checkCounter <= 0)
            {
                checkCounter = timeBetweenChecks;

                if (Vector3.Distance(transform.position, player.transform.position) < PlayerController.instance.pickupRange)
                {
                    movingToPlayer = true;
                    moveSpeed += player.moveSpeed;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CoinController.Instance.AddCoins(coinAmount);
            Destroy(gameObject);
        }
    }
}
