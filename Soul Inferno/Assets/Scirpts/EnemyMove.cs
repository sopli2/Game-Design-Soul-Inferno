using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    private int waypointIndex = 0;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    private void Update()
    {
        // Move Enemy
        Move();

    }

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
        
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
            spriteRenderer.flipX = false;
        }
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
            spriteRenderer.flipX = true;
        }
    }
}