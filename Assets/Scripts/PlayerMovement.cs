using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    private PlayerHealth playerHealth;

    float horizontalMove = 0f;
    public float runspeed = 40f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.health > 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
            animator.SetFloat("horizontalSpeed", Mathf.Abs(horizontalMove));
            if (Input.GetKeyDown("z"))
            {
                jump = true;
            }
        }
        else
        {
            horizontalMove = 0;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
