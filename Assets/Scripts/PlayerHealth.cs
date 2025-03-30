using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private float maxLife;
    [SerializeField] GameManager gameManager;
    private void Start()
    {
        life = maxLife;
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            gameManager.YouLose();
        }
    }
}
