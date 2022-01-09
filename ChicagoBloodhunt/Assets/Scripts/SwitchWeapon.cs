using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switchWeapons();
        }
    }

    void switchWeapons()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(!weapon.gameObject.activeSelf);
        }
    }
}
