using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void Death()
    {
        anim.SetTrigger("Death");
        StartCoroutine(RemoveBody());    
    }

    IEnumerator RemoveBody()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
