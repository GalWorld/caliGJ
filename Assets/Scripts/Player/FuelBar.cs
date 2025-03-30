using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeMaximumFuel(float maxFuel)
    {
        slider.maxValue = maxFuel;
    }

    public void ChangeCurrentFuel(float amountFuel)
    {
        slider.value = amountFuel;
    }

    public void StartFuelBar(float amountFuel)
    {
        ChangeMaximumFuel(amountFuel);
        ChangeCurrentFuel(amountFuel);
    }
}
