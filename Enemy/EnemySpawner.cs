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

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;    
    }

    // Update is called once per frame
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
        // Determine which spawn point to use (left or right)
        Transform spawnPoint = (Random.Range(0, 2) == 0) ? leftSpawnPoint : rightSpawnPoint;

        // Instantiate the enemy at the chosen spawn point
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Get references to the enemy's behavior scripts
        PatrollingEnemy patrollingScript = spawnedEnemy.GetComponent<PatrollingEnemy>();
        EnemyMovement movementScript = spawnedEnemy.GetComponent<EnemyMovement>();

        // Set the enemy's behavior based on the current scene
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            patrollingScript.enabled = true;
            movementScript.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "SecondSampleScene")
        {
            patrollingScript.enabled = false;
            movementScript.enabled = true;
        }

        // Set the next spawn time
        nextSpawnTime = Time.time + spawnInterval;
    }

}
