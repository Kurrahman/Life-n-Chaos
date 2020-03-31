using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    private Animator animator;
    public int worth;
    public int health;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            animator.Play("Hit");
            Globals.score += worth;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        animator.Play("Hit");
        health -= damage;
    }
}
