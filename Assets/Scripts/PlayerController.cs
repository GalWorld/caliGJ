using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float fuel = 100f;
    [SerializeField] private float fuelConsumptionRate = 5f;
    [SerializeField] private FuelBar fuelbar;
    [SerializeField] GameManager gameManager;

    private Rigidbody2D playerRB;
    private Vector2 moveInput;
    private Vector2 lastDirection = Vector2.down;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        fuelbar.StartFuelBar(fuel);
    }


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveInput = new Vector2 (moveX,moveY).normalized;

        if (moveInput != Vector2.zero && fuel > 0f)
        {
            lastDirection = moveInput;

            fuel -= fuelConsumptionRate * Time.deltaTime;
            fuel = Mathf.Clamp(fuel, 0f, 100f); 
            fuelbar.ChangeCurrentFuel(fuel);

            // Rotación del submarino
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            playerRB.rotation = angle - 90f;
        }

        if (fuel <= 0f)
        {
            speed = 0f;
            gameManager.YouLose();
        }
    }

    private void FixedUpdate() 
    {
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.fixedDeltaTime);
    }

    public Vector2 GetCurrentDirection()
    {
        return lastDirection;;
    }
}
