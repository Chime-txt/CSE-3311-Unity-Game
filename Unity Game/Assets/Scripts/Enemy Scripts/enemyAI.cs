using System;
using Pathfinding;
using UnityEngine;

public class enemyAI: MonoBehaviour
{
	[Header("Players")]
	[SerializeField] Transform player1, player2;

	[Header("Enemy")]
	private Transform target;
	[SerializeField] float speed = 200f;
	[SerializeField] float nextWaypointDistance = 3f;
	[SerializeField] float stoppingDistance = 10f;
	[SerializeField] float retreatDistance =  4f;
	Path path;

	private SpriteRenderer spriteRenderer;

	bool reachedEndOfPath;
	int currentWaypoint;

	Rigidbody2D rb;
	Seeker seeker;

	// Start is called before the first frame update
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
		seeker = GetComponent<Seeker>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		reachedEndOfPath = false;
		currentWaypoint = 0;

		InvokeRepeating("UpdatePath", 0f, .5f);
	}
	void UpdatePath()
	{
		if ((player1 != null) && (player2 != null))
		{
			SwitchTarget();
			seeker.StartPath(rb.position, target.position, OnPathComplete);
		}

	}

	void OnPathComplete(Path p)
	{
		if(!p.error)
		{
			path = p;
			currentWaypoint= 0;
		}
	}

	// FixedUpdate is called once every set amount of frames
	void FixedUpdate()
	{
		// Check if the enemy object exists before executing the following functions
		if (target != null)
		{
			RetreatOrForward();
			FlipEnemy();
		}
	}

	// SwitchTarget will switch targets from one player to the other depending on who is closer.
	private void SwitchTarget()
	{
		// Check if both players exists before executing the following functions that includes the players
		if ((player1 != null) && (player2 != null))
		{
			float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
			float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

			// Set target to the closer player
			if (distanceToPlayer1 < distanceToPlayer2)
			{
				target = player1;
			}
			else
			{
				target = player2;
			}
		}
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
