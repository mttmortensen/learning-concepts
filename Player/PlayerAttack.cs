using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D attackCollider;

    void Update()
    {
        if (Input.GetKeyDown("x"))
            Attack();   
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");

    }



}
