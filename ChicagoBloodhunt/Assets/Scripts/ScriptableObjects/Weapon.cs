using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapons")]
public class Weapon : ScriptableObject
{
    new public string name = "New Weapon";  // Weapon name
    public Sprite icon;                     // Weapon pickup sprite
    public bool isAutomatic = false;        // is weapon automatic, will it fire full auto
    public bool useSpread = false;          // use weapon if the weapon needs to have spread
    public float spread = 0f;               // value of weapon spread
    public bool isMultishot = false;         // is weapon using multishoot, does it shoot one than more bullet per shoot
    public int multishootRate = 1;         // how many bullets should a gun shoot per shoot
    public float fireRate = 1f;             // weapon fire rate
    public float damage = 1f;               // weapon damage on hit
    public float bulletLifetime = 2f;       // lifetime of a bullet, what is the range of the weapon
    public RuntimeAnimatorController animatorController;           // animator name to be used with current weapon
}
