using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchWeapon : MonoBehaviour
{
    Weapon currentWeapon; // Weapon currently used by the player

    private void Update()
    {
        if (gameObject.GetComponent<VampireBuff>().vampBuff) return;

        // If player pressed the Q, then he will switch weapon to the next one in his inventory
        if (Input.GetKeyDown(KeyCode.Q) && !(GameObject.Find("Player").GetComponent<Shooting>().currentWeapon == null))
        {
            Debug.Log("Switching weapons");
            currentWeapon = GameObject.Find("Player").GetComponent<Shooting>().currentWeapon;
            GameObject.Find("PlayerGFX").GetComponent<Animator>().runtimeAnimatorController = WeaponsInventory.instance.NextWeapon(currentWeapon).animatorController;
            GameObject.Find("Player").GetComponent<Shooting>().currentWeapon = WeaponsInventory.instance.NextWeapon(currentWeapon);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && WeaponsInventory.instance.weapons.Any() && (GameObject.Find("Player").GetComponent<Shooting>().currentWeapon == null))
        {
            GameObject.Find("PlayerGFX").GetComponent<Animator>().runtimeAnimatorController = WeaponsInventory.instance.weapons[1].animatorController;
            GameObject.Find("Player").GetComponent<Shooting>().currentWeapon = WeaponsInventory.instance.weapons[1];
        }
    }

}
