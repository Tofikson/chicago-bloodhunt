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
    public float fireRate = 1f;             // weapon fire rate
    public float damage = 1f;               // weapon damage on hit
}
