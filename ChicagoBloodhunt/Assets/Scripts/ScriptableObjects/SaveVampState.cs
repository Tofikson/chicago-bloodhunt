using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVampState : ScriptableObject
{
    private static bool vampBuff = false;
    private static float durationLeft = 0f;
    private static bool started;
    private static float normalJump;
    private static float normalSpeed;
    private static Weapon lastWeapon;

    public static void SaveVamp()
    {
        vampBuff = GameObject.Find("Player").GetComponent<VampireBuff>().vampBuff;
        durationLeft = GameObject.Find("Player").GetComponent<VampireBuff>().duration;
        normalJump = GameObject.Find("Player").GetComponent<VampireBuff>().normalJump;
        normalSpeed = GameObject.Find("Player").GetComponent<VampireBuff>().normalSpeed;
        lastWeapon = GameObject.Find("Player").GetComponent<VampireBuff>().lastWeapon;
        started = GameObject.Find("Player").GetComponent<VampireBuff>().buffStarted;
    }

    public static void LoadVamp()
    {
        GameObject.Find("Player").GetComponent<VampireBuff>().vampBuff = vampBuff;
        GameObject.Find("Player").GetComponent<VampireBuff>().duration = durationLeft;
        GameObject.Find("Player").GetComponent<VampireBuff>().normalJump = normalJump;
        GameObject.Find("Player").GetComponent<VampireBuff>().normalSpeed = normalSpeed;
        GameObject.Find("Player").GetComponent<VampireBuff>().lastWeapon = lastWeapon;
        GameObject.Find("Player").GetComponent<VampireBuff>().buffStarted = started;
        GameObject.Find("Player").GetComponent<VampireBuff>().VampFormAnimation();
    }
}
