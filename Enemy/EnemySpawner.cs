using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public EnemyManager enemyManager; // Reference to the central EnemyManager

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (enemyManager.currentNumberOfEnemies < enemyManager.maxNumberOfEnemies)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (enemyManager.currentNumberOfEnemies < enemyManager.maxNumberOfEnemies)
        {
            GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            EnemyMovement movementScript = spawnedEnemy.GetComponent<EnemyMovement>();
            if (movementScript != null)
            {
                movementScript.playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
            }
            enemyManager.EnemySpawned(); // Notify the manager that an enemy has been spawned
        }
    }
}



