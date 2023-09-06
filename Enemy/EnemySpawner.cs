using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    private float nextSpawnTime;

    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        Transform spawnPoint = (Random.Range(0, 2) == 0) ? leftSpawnPoint : rightSpawnPoint;
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        PatrollingEnemy patrollingScript = spawnedEnemy.GetComponent<PatrollingEnemy>();
        EnemyMovement movementScript = spawnedEnemy.GetComponent<EnemyMovement>();

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            patrollingScript.enabled = true;
            movementScript.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "SecondSampleScene")
        {
            patrollingScript.enabled = false;
            movementScript.enabled = true;

            if (spawnPoint == leftSpawnPoint)
            {
                movementScript.MoveRight();
            }
            else
            {
                movementScript.MoveLeft();
            }
        }
    }
}
