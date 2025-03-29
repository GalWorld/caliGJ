using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeVision : MonoBehaviour
{
    [SerializeField] private EnemiesMovement enemiesMovement;
    private Vector3 lastKnownPosition;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            enemiesMovement.isChasing = true;
            enemiesMovement.isReturningToPatrol = false;
            enemiesMovement.speed = 3f; 
        }

        // if (other.CompareTag("Hide"))
        // {
            
        //     enemiesMovement.isChasing = false;
        //     enemiesMovement.isReturningToPatrol = true;
        //     enemiesMovement.speed = 1f; 
        // }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            lastKnownPosition = other.transform.position;
            enemiesMovement.isChasing = false;

            StartCoroutine(CheckLastKnownPosition());
        }
        
    }

    // private void OnTriggerStay2D(Collider2D other) {
    //     if (other.CompareTag("Hide"))
    //     {
            
    //         enemiesMovement.isChasing = false;
    //         enemiesMovement.isReturningToPatrol = true;
    //         enemiesMovement.speed = 1f; 
    //     }
    // }

    public IEnumerator CheckLastKnownPosition()
    {
        
        enemiesMovement.MoveToLastPosition(lastKnownPosition);
        

       
        yield return new WaitUntil(() => enemiesMovement.ReachedLastPosition());

      
        enemiesMovement.isReturningToPatrol = true;

       
    }

    
}