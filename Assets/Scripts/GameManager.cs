using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isDiverRescued = false;
    public GameObject probe;
    private GameObject player;
    private EnemiesMovement enemiesMovement;
    public List<GameObject> spawnedProbes = new List<GameObject>();
    [SerializeField] UIController uiController;
    //private RangeVision rangeVision;
    private bool isCooldown = false;  
    private int cooldownTime = 5;  
    private int currentCooldownTime = 0;  
    public Text coolDownText;

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
      
        if (Input.GetKeyDown(KeyCode.B) && !isCooldown)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            Vector2 direction = playerController.GetCurrentDirection();

            GameObject newProbe = Instantiate(probe, player.transform.position, Quaternion.identity);

            newProbe.GetComponent<LightProbe>().SetDirection(direction);

            spawnedProbes.Add(newProbe);

           
            isCooldown = true;
            currentCooldownTime = cooldownTime;  
            StartCoroutine(CooldownCoroutine());  
            
        }
    }

    public void checkListProbe()
    {
        if (spawnedProbes.Count < 1)
        {
            enemiesMovement.isReturningToPatrol = true;
        }
    }

    // Coroutine para manejar el cooldown de la sonda
    private IEnumerator CooldownCoroutine()
    {
       
        while (currentCooldownTime > 0)
        {
            coolDownText.text = "" + currentCooldownTime;  
            yield return new WaitForSeconds(1f);  
            currentCooldownTime--; 
        }
        
        isCooldown = false;
        coolDownText.text = "Press B";
        Debug.Log("siguiente sonda papi.");
    }
    public void DiverIsFree ()
    {
        isDiverRescued = true;
        RangeVision[] allRangeVisions = FindObjectsOfType<RangeVision>();
        foreach (RangeVision vision in allRangeVisions)
        {
            vision.IncreaseColliderSize(5f);
        }
        uiController.ShowMessage("ESCAPA, YA VIENEN");
        uiController.ShowCountdown(20);
    }

    public void YouWin()
    {
        Debug.Log("Ganaste");
    }

    public void YouLose()
    {
        Debug.Log("Perdiste");
    }
}
