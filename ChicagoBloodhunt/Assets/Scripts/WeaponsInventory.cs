using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponsInventory : MonoBehaviour
{

    #region Singleton
    public static WeaponsInventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one inventory instance");
        }
        instance = this;
    }
    #endregion

    public List<Weapon> weapons = new List<Weapon>();

    public void Add(Weapon weapon)
    {
        if(!weapons.Contains(weapon))
        {
            weapons.Add(weapon);
        }
        else
        {
            Debug.Log("Player already owns weapon of " + weapon.name + " type");
        }
    }

    public Weapon NextWeapon(Weapon weapon)
    {
        int currentIndex = weapons.IndexOf(weapon);
        int targetIndex = currentIndex + 1;

        if (currentIndex == weapons.Count() - 1)
        {
            return weapons[0];
        }
        else
        {
            return weapons[targetIndex];
        }
    }
}
