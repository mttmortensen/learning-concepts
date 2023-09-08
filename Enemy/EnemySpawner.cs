using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public float maxNumberOfEnemies; // Max amount of enemies I want

    private float currentNumberOfEnemies; // Keeps track of current enemy count

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (currentNumberOfEnemies < maxNumberOfEnemies)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
            currentNumberOfEnemies++; // Increment the counter each time an enemy is spawned
        }
    }

    private void SpawnEnemy()
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        EnemyMovement movementScript = spawnedEnemy.GetComponent<EnemyMovement>();
        if (movementScript != null)
        {
            movementScript.playerToFollow = GameObject.FindGameObjectWithTag("Player").transform; // Assuming your player has the tag "Player"
        }
    }


}


