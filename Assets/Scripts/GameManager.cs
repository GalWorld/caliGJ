// GameManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isDiverRescued = false;
    public GameObject probe;
    private GameObject player;
    private EnemiesMovement enemiesMovement;
    public List<GameObject> spawnedProbes = new List<GameObject>();

    void Start()
    {
        player = GameObject.Find("PLAYER");
        isDiverRescued = false;
        Debug.Log("Estado de rescate del buzo: " + isDiverRescued);
        enemiesMovement = FindObjectOfType<EnemiesMovement>();
       
    }

    void Update()
    {
        spawnProbe();
        checkListProbe();
    }

    public void spawnProbe()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
           
            GameObject newProbe = Instantiate(probe, player.transform.position, Quaternion.identity);
            spawnedProbes.Add(newProbe);
            
        }
    }

    public void checkListProbe()
    {
        if(spawnedProbes.Count<1)
        {
            enemiesMovement.isReturningToPatrol=true;

        }

    }
}
