using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// !!!------------------------------------------------------------------------------!!!
//      Use only to save player inventory and current weapon in different Scene !!!
//      It may be changed if we'll need to store some other data than only this
// !!!------------------------------------------------------------------------------!!!

public class SaveWeapons : ScriptableObject
{
    private static List<Weapon> weapons = new List<Weapon>();
    private static Weapon currentWeapon;

    public static void Save()
    {
        weapons = WeaponsInventory.instance.weapons;
        currentWeapon = GameObject.Find("Player").GetComponent<Shooting>().currentWeapon;
    }

    public static void Load()
    {
        WeaponsInventory.instance.weapons = weapons;
        GameObject.Find("Player").GetComponent<Shooting>().currentWeapon = currentWeapon;
    }
}
