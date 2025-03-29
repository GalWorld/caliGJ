using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject messageObject; 
    [SerializeField] Text messageText;         
    [SerializeField] float displayTime = 2f; 
    [SerializeField] GameObject countdownObject;  
    [SerializeField] Text countdownText; 

    private Coroutine countdownCoroutine;

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

    public void ShowCountdown(int seconds)
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        countdownCoroutine = StartCoroutine(CountdownRoutine(seconds));
    }

    private IEnumerator CountdownRoutine(int seconds)
    {
        countdownObject.SetActive(true);

        while (seconds > 0)
        {
            countdownText.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }

        countdownText.text = "0";
        yield return new WaitForSeconds(1f);
        countdownObject.SetActive(false);
    }
}
