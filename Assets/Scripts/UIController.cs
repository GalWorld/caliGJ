using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject messageObject; 
    [SerializeField] Text messageText;         
    [SerializeField] float displayTime = 2f; 

    public void ShowMessage(string message)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessageRoutine(message));
    }

    private IEnumerator ShowMessageRoutine(string message)
    {
        messageText.text = message;
        messageObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        messageObject.SetActive(false);
    }
}
