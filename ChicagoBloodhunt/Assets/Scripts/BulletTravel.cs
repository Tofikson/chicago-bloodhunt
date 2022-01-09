using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public float bulletspeed = 10f;
    public Rigidbody2D impact;

// Start is called before the first frame update
    void Start()
        {
        impact.velocity = transform.right * bulletspeed;
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(gameObject);
    }
    //TODO przeciwnicy i ich ¿ycie
}
