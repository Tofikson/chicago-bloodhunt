using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour, ICollisionHandler
{

    [SerializeField]private Vector2 knockback;
    private Transform target;
    [SerializeField]private float attackCooldown;
    private bool canAttack = true;
    private float timeSinceAttack;
    private float newSpeed;
    public bool isAgro;

    private void Start()
    {
        newSpeed = gameObject.GetComponent<EnemyMovement>().speed * 2;
    }
    private void Update()
    {
        if (!isAgro) return;
        Attack();
    }
    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "Dmg" && other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().playerHit(10f);
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (other.transform.position.x >= gameObject.transform.position.x)
            {
                other.GetComponent<Rigidbody2D>().AddForce(knockback, ForceMode2D.Impulse);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockback.x * -1, knockback.y), ForceMode2D.Impulse);
            }
        }
        if (colliderName == "Dmg" && other.layer == LayerMask.NameToLayer("Bullets"))
        {
            gameObject.GetComponent<EnemyHP>().GetHit(other.GetComponent<BulletTravel>().weapon.damage);
        }
        if (colliderName == "Sight" && other.layer == LayerMask.NameToLayer("Player"))
        {
            isAgro = true;
        }
        else
        {
            isAgro = false;
        }
    }


    public void Attack()
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
