// LightProbe.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightProbe : MonoBehaviour
{
    private Light2D spotLight;
    public float minRadius = 1f;
    public float maxRadius = 5f;
    public float speed = 2f;
    private bool increasing = true;
    public float fallSpeed = 0.5f; // editable desde el Inspector
    private float lifeTimeProbe = 3f;
    
    private GameManager gameManager;

    void Awake()
    {
        spotLight = GetComponentInChildren<Light2D>();
        gameManager = FindObjectOfType<GameManager>(); // Obtener la referencia al GameManager
        Destroy(gameObject, lifeTimeProbe); // Destruir el objeto después del tiempo de vida
    }

    void Update()
    {
        lightProbe();
        movementProbe();
    }

    public void lightProbe()
    {
        float current = spotLight.pointLightOuterRadius;

        if (increasing)
        {
            current += Time.deltaTime * speed;
            if (current >= maxRadius)
            {
                current = maxRadius;
                increasing = false;
            }
        }
        else
        {
            current -= Time.deltaTime * speed;
            if (current <= minRadius)
            {
                current = minRadius;
                increasing = true;
            }
        }

        spotLight.pointLightOuterRadius = current;
    }

    public void movementProbe()
    {
        float wave = Mathf.Sin(Time.time * 2f) * 0.1f; // efecto de oleaje vertical pequeño
        transform.position += new Vector3(0, -(fallSpeed + wave), 0) * Time.deltaTime;
    }

    void OnDestroy()
    {
        // Cuando el objeto se destruya, eliminarlo de la lista de probes en el GameManager
        if (gameManager != null)
        {
            gameManager.spawnedProbes.Remove(gameObject);

            Debug.Log("Sonda destruida y eliminada de la lista");
        }
    }
}
