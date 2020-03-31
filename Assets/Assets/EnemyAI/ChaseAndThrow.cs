using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChaseAndThrow : MonoBehaviour
{
    private CharacterController2D controller;
    private List<GameObject> projectiles;
    private GameObject player;
    private Animator animator;
    private Seeker seeker;
    private Path path;

    public GameObject prop;
    public Transform throwingPoint;
    public int pooledObject;
    public float horizontalSpeed;
    public float distance;
    public float range;
    public float power;
    private bool jump;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        seeker = gameObject.GetComponent<Seeker>();
        animator = gameObject.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController2D>();
        seeker.pathCallback += OnPathComplete;

        projectiles = new List<GameObject>();
        for (int i = 0; i < pooledObject; i++)
        {
            projectiles.Add(Instantiate(prop));
            projectiles[i].SetActive(false);
        }
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
            animator.Play("Throw");
        }
    }

    public void Throw()
    {
        GameObject tmpObject = GetPooledObject();
        Vector2 vector2 = player.transform.position - transform.position;
        tmpObject.SetActive(true);
        tmpObject.transform.position = throwingPoint.position;
        tmpObject.GetComponent<Rigidbody2D>().AddForce((vector2 - Physics2D.gravity/2).normalized*power*distance);
    }

    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < projectiles.Count; i++)
        {
            //2
            if (!projectiles[i].activeInHierarchy)
            {
                return projectiles[i];
            }
        }
        //3   
        return null;
    }


    public void OnDisable()
    {
        seeker.pathCallback -= OnPathComplete;
    }
}
