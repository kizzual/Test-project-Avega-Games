using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void RunAnimation()
    {
        animator.SetBool("Run", true);
        animator.SetBool("Attack", false);
    }
    public void AttackAnimation()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Attack", true);

    }
}
