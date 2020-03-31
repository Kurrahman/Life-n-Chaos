using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator[] animator;
    public int health;
    public float invulnerable;
    // Start is called before the first frame update
    void Start()
    {
        health = 6;
        invulnerable = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (invulnerable > 0)
        {
            invulnerable -= Time.deltaTime;
        }
    }

    public void TakeDamage()
    {
        if (invulnerable <= 0)
        {
            health--;
            for (int i = 0; i < 3; i++)
            {
                animator[i].SetInteger("Health", health);
            }
            invulnerable += 1;
        }
    }
}
