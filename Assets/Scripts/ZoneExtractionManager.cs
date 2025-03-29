using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneExtractionManager : MonoBehaviour
{
    [SerializeField] UIController uiController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.isDiverRescued == true)
        {
            uiController.ShowMessage("Te puedes ir");
        }
        else if (collision.CompareTag("Player") && GameManager.isDiverRescued == false)
        {
            uiController.ShowMessage("No puedes dejar al buzo");
        }
    }
}
