using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;

    public Transform player;

    private bool bossSpawned = false;

    public void SpawnBoss()
    {
        if (!bossSpawned && bossPrefab && bossSpawnPoint)
        {
            Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
            bossSpawned = true;
        }
    }

    public bool IsBossSpawned()
    {
        return bossSpawned;
    }

}
