using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Animator anim;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, attackRange, playerLayer);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Attack();
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
