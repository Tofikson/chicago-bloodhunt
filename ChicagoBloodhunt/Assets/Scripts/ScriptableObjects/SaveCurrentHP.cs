using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCurrentHP : ScriptableObject
{
    private static float CurrentHP = GameObject.Find("Player").GetComponent<PlayerHealth>().maxHp;

    public static float LoadHP()
    {
        return CurrentHP;
    }

    public static void SaveHP(float hp)
    {
        CurrentHP = hp;
    }
}
