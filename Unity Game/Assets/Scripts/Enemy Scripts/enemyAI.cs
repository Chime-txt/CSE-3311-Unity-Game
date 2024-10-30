using System;
using Pathfinding;
using UnityEngine;

public class enemyAI: MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    [SerializeField] public float stoppingDistance =10f;
    [SerializeField] public float retreatDistance =  4f;
    Path path;

    private SpriteRenderer spriteRenderer;

    bool reachedEndOfPath = false;
    int currentWaypoint= 0;
    

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }
    void UpdatePath()
    {
        seeker.StartPath(rb.position, target.position, OnPathComplete);

    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint= 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RetreatOrForward();
        FlipEnemy();

    }

    private void RetreatOrForward()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget > stoppingDistance)
        {
            PathfindingFunction(speed);
        }
        else if (distanceToTarget <= stoppingDistance && distanceToTarget > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (distanceToTarget <= retreatDistance)
        {
            Vector2 retreatDirection = ((Vector3)rb.position - target.position).normalized;
            rb.AddForce(retreatDirection * speed * Time.fixedDeltaTime);
            reachedEndOfPath = true;

            // transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.fixedDeltaTime);
        }
    }

    private void PathfindingFunction(float speed)
    {
        // RetreatOrForward();
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
    void FlipEnemy()
    {

        if (target.transform.position.x < rb.position.x)
        {
            spriteRenderer.flipX = false; // Flip sprite when mouse is to the left
        }
        else
        {
            spriteRenderer.flipX = true; // Don't flip when mouse is to the right
        }
    }
}