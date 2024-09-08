using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyTospawn;

    public Vector2 minSpawnPoint;
    public Vector2 maxSpawnPoint; 

    public float timeToSpawn;
    private float spawnCounter;

    private GameObject player;

    private float despawnDistance;

    private List<GameObject> spawnEnemies = new List<GameObject>();

    public int checkPerFrame = 10;
    private int enemyToCheck;

    private void Start()
    {
        spawnCounter = timeToSpawn;

        player = GameObject.FindWithTag("Player");

        despawnDistance = Vector3.Distance(transform.position, maxSpawnPoint) + 4f;
    }

    private void Update()
    {
        if (player == null) return;

        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;

            GameObject enemy = Instantiate(enemyTospawn, SelectSpawnPoint(), transform.rotation);

            spawnEnemies.Add(enemy);
        }

        int checkTarget = enemyToCheck + checkPerFrame;

        while ( enemyToCheck < checkTarget)
        {
            if (enemyToCheck < spawnEnemies.Count)
            {
                if (spawnEnemies[enemyToCheck] != null)
                {
                    if(Vector3.Distance(transform.position, spawnEnemies[enemyToCheck].transform.position)> despawnDistance)
                    {
                        Destroy(spawnEnemies[enemyToCheck]);

                        spawnEnemies.RemoveAt(enemyToCheck);
                        checkTarget--;
                    }
                    else
                    {
                        enemyToCheck++;
                    }
                }
                else
                {
                    spawnEnemies.RemoveAt(enemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                enemyToCheck = 0;
                checkTarget = 0;
            }
        }
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawnPoint.y, maxSpawnPoint.y);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.x = maxSpawnPoint.x;
            }
            else
            {
                spawnPoint.x = minSpawnPoint.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawnPoint.x, maxSpawnPoint.x);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = maxSpawnPoint.y;
            }
            else
            {
                spawnPoint.y = minSpawnPoint.y;
            }
        }

        return player.transform.position + spawnPoint;
    }
}
