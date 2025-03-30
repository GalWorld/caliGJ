using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject messageObject;
    [SerializeField] Text messageText;
    [SerializeField] TextMeshProUGUI messageTextPro;
    [SerializeField] float displayTime = 2f;
    [SerializeField] GameObject countdownObject;
    [SerializeField] Image DiverLife;
    [SerializeField] GameManager gameManager;
    private Coroutine countdownCoroutine;
    private float fillValue = 1.0f;

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
            // Asegura que el valor esté entre 0 y 1
            fillValue = Mathf.Clamp(fillValue, 0f, 1f);

            // Modifica el fillAmount de la imagen
            DiverLife.fillAmount = fillValue;
            yield return new WaitForSeconds(1f);
            seconds--;
        }

        //countdownText.text = "0";
        yield return new WaitForSeconds(1f);
        countdownObject.SetActive(false);

        if (gameManager != null)
        {
            gameManager.YouLose();
        }
    }
}
