using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject messageObject;
    //[SerializeField] Text messageText;
    [SerializeField] TextMeshProUGUI messageTextPro;
    [SerializeField] float displayTime = 2f;
    [SerializeField] Image DiverLife;
    [SerializeField] GameManager gameManager;
    private Coroutine countdownCoroutine;
    [SerializeField] float fillValue = 1.0f;
    [SerializeField] GameObject buzzBar;

    void Start()
    {
        ShowCountdown(60);
    }
    public void ShowMessage(string message)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessageRoutine(message));
    }

    private IEnumerator ShowMessageRoutine(string message)
    {
        messageTextPro.text = message;
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

        int originalTime = seconds;

        while (seconds > 0)
        {
            fillValue = (float)seconds / originalTime;
            DiverLife.fillAmount = fillValue;

            yield return new WaitForSeconds(1f);
            seconds--;
        }

        DiverLife.fillAmount = 0f; // Aseguramos que quede vacío visualmente
        yield return new WaitForSeconds(1f);

        if (gameManager != null)
        {
            gameManager.YouLose();
        }
    }
    public void TurnOffBar(){
        buzzBar.SetActive(false);
    }
}
