using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemiesMovement : MonoBehaviour
{
    public Transform[] waypoints;

    public float speed;
    private int currentWaypointIndex = 0;
    private float distanceMin = 0.05f;

    public bool isChasing = false;
    public bool isReturningToPatrol = false;
    private Vector3 lastPosition; 
    public string movingDirection;
    
    private Vector3 lastPositionTarget; 
    private GameObject player;
  
    void Start()
    {
        //animator = GetComponent<Animator>();
        player = GameObject.Find("PLAYER"); 
        movementEnemy();
    }

    void Update()
    {
        if (isChasing)
        {
            chasingPlayer();
        }
        else if (isReturningToPatrol)
        {
            movementEnemy(); 
        }
        else
        {
            movementEnemy(); 
        }

        

        
    }

    private void movementEnemy()
    {
        if (waypoints.Length == 0) return;
        speed=0.5f;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < distanceMin)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) currentWaypointIndex = 0;
        }
    }

    public void chasingPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    public void MoveToLastPosition(Vector3 position)
    {
        lastPositionTarget = position;
        isReturningToPatrol = false; 
    }

    public bool ReachedLastPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, lastPositionTarget, speed * Time.deltaTime);
        return Vector2.Distance(transform.position, lastPositionTarget) > distanceMin;
    }


}