using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int currentHealth = 1;

    public GameObject deathEffect;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void DamageEnemy()
    {
        currentHealth--;
        

        if(currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
