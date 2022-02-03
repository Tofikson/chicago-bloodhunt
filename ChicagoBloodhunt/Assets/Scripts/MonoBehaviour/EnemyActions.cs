using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour, ICollisionHandler
{

    private Transform target;
    [SerializeField]private float attackCooldown;
    private bool canAttack = true;
    private float timeSinceAttack;

    private void Update()
    {
        Attack();
    }
    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "Dmg" && other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().playerHit(10f);
        }
        if (colliderName == "Sight" && other.tag == "Player")
        {
            if (target = null)
            {
                this.target = other.transform;
            }
        }
    }


    private void Attack()
    {
        if (!canAttack)
        {
            timeSinceAttack += Time.deltaTime;
        }
        if (timeSinceAttack >= attackCooldown)
        {
            canAttack = true;
        }
        if (canAttack && target != null && Mathf.Abs(target.transform.position.y - transform.position.y) <= 1)
        {
            canAttack = false;
            timeSinceAttack = 0;
        }
    }
}
