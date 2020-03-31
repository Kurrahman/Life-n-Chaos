using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public Animator animator;
    public int blankHealth = 6;
    int currHealth;
    int befoHealth;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = animator.GetInteger("Health");
        befoHealth = animator.GetInteger("Health");
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = animator.GetInteger("Health");
        if (currHealth <= blankHealth)
        {
            animator.Play("SmallHeartsHit");
            gameObject.transform.position.Set(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+2);
        }
        else if (currHealth == blankHealth + 1)
        {
            if (currHealth < befoHealth)
            {
                animator.Play("HeartsHit");
            }
            else
            {
                animator.Play("SmallHeartsHit");
            }
        }
        else
        {
            animator.Play("HeartsIdle");
        }
        befoHealth = currHealth;
    }
}
