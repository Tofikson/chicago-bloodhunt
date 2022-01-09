using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    //TODO ogieñ ci¹g³y
    void Shoot()
    {
        Instantiate(bullet, FirePoint.position, FirePoint.rotation);
    }
}
