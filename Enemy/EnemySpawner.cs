using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Transform spawnPoint = (Random.Range(0, 2) == 0) ? leftSpawnPoint : rightSpawnPoint;
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        EnemyMovement movementScript = spawnedEnemy.GetComponent<EnemyMovement>();

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


