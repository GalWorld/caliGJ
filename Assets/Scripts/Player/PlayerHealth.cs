using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private float maxLife;
    [SerializeField] GameManager gameManager;
    [SerializeField] LifeBar lifeBar;
    private void Start()
    {
        life = maxLife;
        lifeBar.StartLifeBar(life);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        lifeBar.ChangeCurrentLife(life);
        if (life <= 0)
        {
            gameManager.YouLose();
        }
    }
}
