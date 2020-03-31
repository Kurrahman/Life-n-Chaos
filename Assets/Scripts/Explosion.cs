using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator animator;
    public float explosionRadius;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    private void OnEnable()
    {
        animator.Play("Explode");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, playerLayer);
        foreach (Collider2D collider in colliders)
        {
            collider.GetComponent<PlayerCombat>().TakeDamage();
        }
    }
    public void ReturnToBomb()
    {
        gameObject.SetActive(false);
    }
}
