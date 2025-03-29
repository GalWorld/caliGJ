using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D playerRB;
    private Vector2 moveInput;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveInput = new Vector2 (moveX,moveY).normalized;
    }

    private void FixedUpdate() 
    {
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
