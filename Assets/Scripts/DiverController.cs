using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverController : MonoBehaviour
{
    [SerializeField] UIController uiController;
    [SerializeField] GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            gameManager.DiverIsFree();
            Destroy(this.gameObject);
        }
    }
}
