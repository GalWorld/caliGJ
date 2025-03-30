using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeMaximumLife(float maxLife)
    {
        slider.maxValue = maxLife;
    }

    public void ChangeCurrentLife(float amountLife)
    {
        slider.value = amountLife;
    }

    public void StartLifeBar(float amountLife)
    {
        ChangeMaximumLife(amountLife);
        ChangeCurrentLife(amountLife);
    }
}
