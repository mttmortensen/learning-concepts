using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private new Collider2D collider;

    private bool isDead = false;

    public void Death()
    {
        if(!isDead)
        {
            isDead = true;
            anim.SetTrigger("Death");
            rb.bodyType = RigidbodyType2D.Static;
            collider.enabled = false;
            GetComponent<PatrollingEnemy>().enabled = false;
            GetComponent<EnemyMovement>().enabled = false;
            StartCoroutine(RemoveBody());    
        }
    }

    private IEnumerator RemoveBody()
    {
        // Wait for the length of the death animation
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        // Amount of time before object is destoryed
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
