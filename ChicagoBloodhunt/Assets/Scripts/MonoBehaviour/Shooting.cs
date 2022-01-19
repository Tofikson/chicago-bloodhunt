using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Weapon currentWeapon;    // Weapon currently equiped by character
    public Transform FirePoint;     // Fire point from which the bullets start their travel
    public GameObject bullet;       // Bullet GameObject
    private bool shoot = false;     // Bool to determine if the player wants to shoot the gun.
    private float nextShoot;

    void Update()
    {
        // If character has weapon equiped, player wants to shoot, and weapon is out of cooldown, then change shoot bool to true
        // If not true, then keep the bool as false
        if (currentWeapon != null && Input.GetButton("Fire1") && nextShoot >= currentWeapon.fireRate)
        {
            shoot = true;
        }
        else
        {
            shoot = false;

            // If the weapon is on cooldown, then add time.deltatime to the cooldown
            if (currentWeapon != null && nextShoot <= currentWeapon.fireRate)
            {
                nextShoot += Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        if(currentWeapon != null && shoot)
        {
            if (!currentWeapon.useSpread)
            {
                Shoot();
            }
            else
            {
                ShootSpread();
            }
        }
    }

    void Shoot()
    {
        if (!currentWeapon.isMultishot)
        {
            Instantiate(bullet, FirePoint.position, FirePoint.rotation);
            nextShoot = 0f;
        }
        else
        {
            for(int i=0; i <= currentWeapon.multishootRate; i++)
            {
                Instantiate(bullet, FirePoint.position, FirePoint.rotation);
                nextShoot = 0f;
            }
        }
    }

    void ShootSpread()
    {
        float tempRotZ = FirePoint.rotation.z;

        if (GameObject.Find("Player").GetComponent<CharacterMovement>().isLeft)
        {
            tempRotZ += 180f;
        }

        if (!currentWeapon.isMultishot)
        {
            Instantiate(bullet, FirePoint.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(tempRotZ + -currentWeapon.spread, tempRotZ + currentWeapon.spread)));
            
            nextShoot = 0f;
        }
        else
        {
            for (int i = 0; i < currentWeapon.multishootRate; i++)
            {
                Instantiate(bullet, FirePoint.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(tempRotZ + -currentWeapon.spread, tempRotZ + currentWeapon.spread)));
                nextShoot = 0f;
            }
        }
    }
}
