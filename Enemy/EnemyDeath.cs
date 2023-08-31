using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public void Death()
    {
        Debug.Log("Ah you killed me");
        Destroy(gameObject);
    }

}
