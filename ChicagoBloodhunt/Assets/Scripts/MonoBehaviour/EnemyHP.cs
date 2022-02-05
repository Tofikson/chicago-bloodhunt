using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void GetHit(float dmg)
    {
        currentHealth = currentHealth - dmg;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Regen(float dmg)
    {
        currentHealth = currentHealth + dmg;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
