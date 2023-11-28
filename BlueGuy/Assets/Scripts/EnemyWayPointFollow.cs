using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayPointFollow : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int CurrentWayPointIndex = 0;
    [SerializeField] private float platformspeed = 2f;

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    private void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[CurrentWayPointIndex].transform.position, transform.position) < 0.1f)
        {
            CurrentWayPointIndex++;
            if (CurrentWayPointIndex >= waypoints.Length)
            {
                CurrentWayPointIndex = 0;
            }
        }

        // Calculate the movement direction
        Vector2 moveDirection = waypoints[CurrentWayPointIndex].transform.position - transform.position;

        // Flip the sprite based on the movement direction
        if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        // Move towards the next waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWayPointIndex].transform.position, Time.deltaTime * platformspeed);
    }
}
