using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public Weapon weapon;
    public float bulletspeed = 10f;
    float bulletLifetime;
    public Rigidbody2D impact;

    private float time;

// Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.Find("Player").GetComponent<Shooting>().currentWeapon;
        impact.velocity = transform.right * bulletspeed;
        bulletLifetime = GameObject.Find("Player").GetComponent<Shooting>().currentWeapon.bulletLifetime;
    }

    private void Update()
    {
        if(bulletLifetime > time)
        {
            time += Time.deltaTime;
        }
        else
        {
            Debug.Log("Bullet time out");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(gameObject);
    }
}
