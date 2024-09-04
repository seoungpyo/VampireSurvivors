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

    private void Start()
    {
        spawnCounter = timeToSpawn;

        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;

            Instantiate(enemyTospawn, SelectSpawnPoint(), transform.rotation);
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
