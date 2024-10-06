using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyTospawn;

    public Vector2 minSpawnPoint;
    public Vector2 maxSpawnPoint; 

    public int checkPerFrame = 10;
    public float timeToSpawn;

    private float spawnCounter;
    private float despawnDistance;
    private int enemyToCheck;
    private Transform target;
    private List<GameObject> spawnEnemies = new List<GameObject>();
    
    public List<WaveInfo> waves;
    private int currentWave;
    private float waveCounter;

    private void Start()
    {
        spawnCounter = timeToSpawn;

        target = GameManager.Instance.player.transform;

        despawnDistance = Vector3.Distance(transform.position, maxSpawnPoint) + 4f;

        currentWave = -1;
        GoToNextWave();
    }

    private void Update()
    {
        if (target == null) return;

        //spawnCounter -= Time.deltaTime;
        //if (spawnCounter <= 0)
        //{
        //    spawnCounter = timeToSpawn;

        //    GameObject enemy = Instantiate(enemyTospawn, SelectSpawnPoint(), transform.rotation);

        //    spawnEnemies.Add(enemy);
        //}

        if (GameManager.Instance.player.gameObject.activeSelf)
        {
            if(currentWave< waves.Count)
            {
                waveCounter -= Time.deltaTime;
                if(waveCounter <= 0)
                {
                    GoToNextWave();
                }

                spawnCounter -= Time.deltaTime;
                if(spawnCounter <= 0)
                {
                    spawnCounter = waves[currentWave].timeBetweenSpawn;

                    GameObject newEnemy = Instantiate(waves[currentWave].enemyToSpawn, SelectSpawnPoint(), Quaternion.identity);

                    spawnEnemies.Add(newEnemy);
                }
            }
        }

        transform.position = target.position;

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
                spawnPoint.x = transform.position.x + maxSpawnPoint.x;
            }
            else
            {
                spawnPoint.x = transform.position.x + minSpawnPoint.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawnPoint.x, maxSpawnPoint.x);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = transform.position.y + maxSpawnPoint.y;
            }
            else
            {
                spawnPoint.y = transform.position.y + minSpawnPoint.y;
            }
        }

        return spawnPoint;
    }

    public void GoToNextWave()
    {
        currentWave++;

        if(currentWave >= waves.Count)
        {
            currentWave = waves.Count - 1;
        }

        waveCounter = waves[currentWave].waveLength;
        spawnCounter = waves[currentWave].timeBetweenSpawn;
    }
}

[System.Serializable]
public class WaveInfo 
{
    public GameObject enemyToSpawn;
    public float waveLength = 10f;
    public float timeBetweenSpawn = 1f;
}