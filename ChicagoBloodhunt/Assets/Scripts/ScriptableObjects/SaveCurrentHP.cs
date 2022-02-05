using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCurrentHP : ScriptableObject
{
    private static float CurrentHP = GameObject.Find("Player").GetComponent<PlayerHealth>().maxHp;
    private static int CurrentAntidote = GameObject.Find("Player").GetComponent<AntidoteScript>().currentAntidote;

    public static float LoadHP()
    {
        return CurrentHP;
    }

    public static int LoadAntidote()
    {
        return CurrentAntidote;
    }

    public static void SaveHP(float hp)
    {
        CurrentHP = hp;
    }

    public static void SaveAntidote(int an)
    {
        CurrentAntidote = an;
    }
}
