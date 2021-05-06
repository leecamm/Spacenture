using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the seeker component
        seeker = GetComponent<Seeker>();
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Update the path for the enemies
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        // If the seeker IsDone
        if(seeker.IsDone())
            // Make the enemy move to the targets position
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        // If the enemy completed the path
        if(!p.error)
        {
            // Make it reset
            path = p;
            // Set waypoints to 0
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If there is no path try to search for a new one
        if (path == null)
            return;

        // If currentWaypoint is bigger or equal to the path count do this
        if(currentWaypoint >= path.vectorPath.Count)
        {
            // The enemy reached the end
            reachedEndOfPath = true;
            // Start over
            return;
        }
        else
        {
            // The enemy still needs to reach the end
            reachedEndOfPath = false;
        }

        // Check the direction
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        // Checking the distance
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        // If the distance is smaller than the next waypoint
        if(distance < nextWaypointDistance)
        {
            // Add 1 value to the waypoints
            currentWaypoint++;
        }

        // Check the enemies position, make them move to the right way and make the image rotate correctly
        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }
        else if (force.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }
}
