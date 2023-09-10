using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager Instance; // Singleton

    public int maxNumberOfEnemies = 15; // Max amount of enemies allowed to spawn 
    public int currentNumberOfEnemies = 0;  // Keeps track of current enemy count 
    public int totalEnemiesSpawned = 0; // Keeps track of the total enemies spawned

    public BossSpawner bossSpawner;

    private void Awake()
    {
        // Singleton Pattern
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            return;
        }

        // Reset the current number of enemies
        currentNumberOfEnemies = 0;

    }

    public bool CanSpawnEnemy()
    {
        return currentNumberOfEnemies < maxNumberOfEnemies && !bossSpawner.IsBossSpawned();
    }

    public void EnemySpawned()
    {
        currentNumberOfEnemies++;
        totalEnemiesSpawned++;
    }

    public void EnemyDefeated()
    {
        currentNumberOfEnemies--;

        //Checking if all enemies have been defeated 
        if (currentNumberOfEnemies <= 0)
            bossSpawner.SpawnBoss();
    }

    public bool ReachedMaxSpawnList()
    {
        return totalEnemiesSpawned >= maxNumberOfEnemies;
    }

}
