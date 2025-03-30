using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeVision : MonoBehaviour
{
    [SerializeField] private EnemiesMovement enemiesMovement;
    private Vector3 lastKnownPosition;
    [SerializeField] GameManager gameManager;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] float ChangeSize = 5f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            enemiesMovement.isChasing = true;
            enemiesMovement.isReturningToPatrol = false;
            enemiesMovement.speed = 3f; 

           
        }
         if(other.CompareTag("Probe"))
        {
            
            enemiesMovement.isChasingProbe = true;
            enemiesMovement.isReturningToPatrol = false;
            enemiesMovement.speedProbe= 3f; 
            Debug.Log("Entro con la sonda");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            lastKnownPosition = other.transform.position;
            enemiesMovement.isChasing = false;
            enemiesMovement.isReturningToPatrol=true;

        }
        if (other.CompareTag("Probe"))
        {
            lastKnownPosition = other.transform.position;
            enemiesMovement.isChasingProbe = false;
            enemiesMovement.isReturningToPatrol=true;
 
        }

    }
    public void IncreaseColliderSize(float ChangeSize)
    {
        boxCollider.size += new Vector2(ChangeSize, ChangeSize);
    }
}