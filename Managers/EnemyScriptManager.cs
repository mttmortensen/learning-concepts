using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScriptManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private void Start()
    {
        StartCoroutine(DelayedAdjustment());
    }

    private IEnumerator DelayedAdjustment()
    {
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        AdjustEnemyScriptsBasedOnScene();
    }

    private void AdjustEnemyScriptsBasedOnScene()
    {
        // Adjust the prefab
        AdjustScriptsForEnemy(enemyPrefab);

        // Adjust all existing enemies in the scene
        EnemyMovement[] allEnemies = GameObject.FindObjectsOfType<EnemyMovement>();
        foreach (EnemyMovement enemy in allEnemies)
        {
            AdjustScriptsForEnemy(enemy.gameObject);
        }
    }


    private void AdjustScriptsForEnemy(GameObject enemy)
    {
        // Get references to the enemy behavior scripts
        PatrollingEnemy patrollingScript = enemy.GetComponent<PatrollingEnemy>();
        EnemyMovement movementScript = enemy.GetComponent<EnemyMovement>();

        string currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "SampleScene":
                patrollingScript.enabled = true;
                movementScript.enabled = false;
                break;
            case "SecondSampleScene":
                movementScript.enabled = true;
                patrollingScript.enabled = false;
                break;
                // Add more cases if you have more scenes and enemy behaviors
        }
    }
}




