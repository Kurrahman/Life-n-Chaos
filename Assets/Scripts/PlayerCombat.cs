using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    private PlayerHealth playerHealth;

    public float attackRadius = 0.2f;

    private float nextSwing;
    public float swingRate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = gameObject.GetComponent<PlayerHealth>();
        animator.SetInteger("health", 6);
        nextSwing = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("x") && Time.time > nextSwing) && (playerHealth.health > 0))
        {
            animator.Play("Attack");
            nextSwing = Time.time + swingRate;
        }
    }

    void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);
        foreach (Collider2D collider in colliders)
        {
            collider.GetComponent<Health>().TakeDamage(1);
        }
    }

    public void TakeDamage()
    {
        if (playerHealth.health > 0)
        {
            playerHealth.TakeDamage();
            animator.Play("Hit");
            animator.SetInteger("health", playerHealth.health);
        }
    }

    public void Dead()
    {
        SceneManager.LoadScene("GameOver");
    }
    /*
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
    */
}
