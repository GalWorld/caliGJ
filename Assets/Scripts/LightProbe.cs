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
    // Start is called before the first frame update
    public float fallSpeed = 0.5f; // editable desde el Inspector
    private float lifeTimeProbe= 5f;

   void Awake()
{
    spotLight = GetComponentInChildren<Light2D>();
    Destroy(gameObject,lifeTimeProbe);
}

    // Update is called once per frame
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
}
