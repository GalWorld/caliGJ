using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isDiverRescued = false;
    public GameObject probe;
    private GameObject player;
    

    void Start()
    {
        player = GameObject.Find("PLAYER");
        isDiverRescued = false;
        Debug.Log("Estado de rescate del buzo: " + isDiverRescued);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        spawnProbe();
        
    }
    

    public void spawnProbe()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(probe,player.transform.position,Quaternion.identity);

        }
        
    
    }
}
