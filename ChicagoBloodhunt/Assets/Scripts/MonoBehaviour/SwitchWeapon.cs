using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    Weapon currentWeapon; // Weapon currently used by the player

    private void Update()
    {
        // If player pressed the Q, then he will switch weapon to the next one in his inventory
        if (Input.GetKeyDown(KeyCode.Q) && !(GameObject.Find("Player").GetComponent<Shooting>().currentWeapon == null))
        {
            Debug.Log("Switching weapons");
            currentWeapon = GameObject.Find("Player").GetComponent<Shooting>().currentWeapon;
            GameObject.Find("Player").GetComponent<Shooting>().currentWeapon = WeaponsInventory.instance.NextWeapon(currentWeapon);
        }
    }

}
