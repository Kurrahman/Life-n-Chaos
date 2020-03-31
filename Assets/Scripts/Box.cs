using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public LayerMask playerLayer;
    // Start is called before the first frame update
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, playerLayer);
        foreach (Collider2D collider in colliders)
        {
            collider.GetComponent<PlayerCombat>().TakeDamage();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
