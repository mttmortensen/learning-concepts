using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval;
    public float spacingRadius = 1f; // Radius to check for nearby enemies
    public GameObject enemyPrefab; // Ref to Enemy Prefab (Skelly)
    public EnemyManager enemyManager; // Reference to the central EnemyManager
    public LayerMask enemyLayerMask; // LayerMask to specify which layers to check for collisions

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
        // Check for enemies within the specified radius of the spawn point
        Collider2D enemyNearby = Physics2D.OverlapCircle(transform.position, spacingRadius, enemyLayerMask);

        // If there's no enemy too close to the spawn point and we haven't reached the max number of enemies
        if (enemyNearby == null && enemyManager.currentNumberOfEnemies < enemyManager.maxNumberOfEnemies)
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




