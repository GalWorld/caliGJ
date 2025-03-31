// EnemiesMovement.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    public float speedProbe= 3;
    private int currentWaypointIndex = 0;
    private float distanceMin = 0.05f;
    public bool isChasing = false; 
    public bool isChasingProbe = false;
    public bool isReturningToPatrol = false;
    private GameObject player;
    private GameObject probe;
    private RangeVision rangeVision;
    private GameManager gameManager;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] float damage = 30;

    void Start()
    {
        player = GameObject.Find("PLAYER"); 
        movementEnemy();
        rangeVision = FindObjectOfType<RangeVision>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Acceder al primer probe instanciado (si existe)
        if (gameManager.spawnedProbes.Count > 0)
        {
            probe = gameManager.spawnedProbes[0];
            
        }
        if (isChasingProbe)
        {
            chasingProbe();
        }else if (isReturningToPatrol)
        {
            movementEnemy(); 
        }
         

        if (isChasing)
        {
            chasingPlayer();
        }
        else if (isReturningToPatrol)
        {
            movementEnemy(); 
        }
        // else
        // {
        //     movementEnemy(); 
        // }   
    }

    private void movementEnemy()
    {
        if (waypoints.Length == 0) return;
        speed = 4f;

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
        if (isChasing)
        speed = 5f;
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void chasingProbe()
    {
        if (isChasingProbe && probe != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, probe.transform.position, speedProbe * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);

        }
    }
}
