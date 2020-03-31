using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class ChaseAndHit : MonoBehaviour
{
    private CharacterController2D controller;
    private GameObject player;
    private Animator animator;
    public Transform attackPoint;
    private Seeker seeker;
    private Path path;
    public LayerMask enemyLayers;

    public float horizontalSpeed;
    public float attackRadius = 0.2f;
    public float distance;
    public float range;
    private bool jump;
    private bool drop;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController2D>();
        animator = gameObject.GetComponent<Animator>();
        seeker = gameObject.GetComponent<Seeker>();
        player = GameObject.FindGameObjectWithTag("Player");
        seeker.pathCallback += OnPathComplete;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null)
        {
            return;
            
        }

        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 dir = (path.vectorPath[1] - transform.position).normalized;

        jump = dir.y > 0.1;
        if (dir.x > 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        animator.SetBool("jump", jump);
        animator.SetFloat("distance", direction);
        animator.SetFloat("direction", direction);
    }
    private void FixedUpdate()
    {
        seeker.StartPath(transform.position, player.transform.position);
        if (distance > range)
        {
            controller.Move(direction * horizontalSpeed * Time.deltaTime, false, jump);
        }
        else
        {
            animator.Play("Attack");
        }
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);
        foreach (Collider2D collider in colliders)
        {
            collider.GetComponent<PlayerCombat>().TakeDamage();
        }
    }

    public void OnDisable()
    {
        seeker.pathCallback -= OnPathComplete;
    }
}
