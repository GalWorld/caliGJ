using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeVision : MonoBehaviour
{
    [SerializeField] private EnemiesMovement enemiesMovement;
    private Vector3 lastKnownPosition;
    private GameManager gameManager;
   

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            enemiesMovement.isChasing = true;
            enemiesMovement.isReturningToPatrol = false;
            enemiesMovement.speed = 2f; 

           
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

           // StartCoroutine(CheckLastKnownPosition());
            
            
        }
        if (other.CompareTag("Probe"))
        {
            lastKnownPosition = other.transform.position;
            enemiesMovement.isChasingProbe = false;
            enemiesMovement.isReturningToPatrol=true;
           // StartCoroutine(CheckLastKnownPosition());
            
        }


        
    }


//     public IEnumerator CheckLastKnownPosition()
//     {
        
//         enemiesMovement.MoveToLastPosition(lastKnownPosition);
        

       
//         yield return new WaitUntil(() => enemiesMovement.ReachedLastPosition());

      
//         enemiesMovement.isReturningToPatrol = true;

       
//     }

    
// }
}