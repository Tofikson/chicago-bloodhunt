using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public float bulletspeed = 10f;
    public float bulletLifetime = 5f;
    public Rigidbody2D impact;

    private float time;

// Start is called before the first frame update
    void Start()
    {
        impact.velocity = transform.right * bulletspeed;
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
    //TODO przeciwnicy i ich ¿ycie
}
