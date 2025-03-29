using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverController : MonoBehaviour
{
    [SerializeField] UIController uiController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            GameManager.isDiverRescued = true;
            uiController.ShowMessage("ESCAPA, YA VIENEN");
            Destroy(this.gameObject);
        }
    }
}
