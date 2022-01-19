using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    private Weapon lastWeapon;

    private void Update()
    {
        if(lastWeapon != GameObject.Find("Player").GetComponent<Shooting>().currentWeapon)
        {
            GameObject.Find("WeaponSprite").GetComponent<RawImage>().color = Color.white;
            WeaponChange(GameObject.Find("Player").GetComponent<Shooting>().currentWeapon.icon);
            lastWeapon = GameObject.Find("Player").GetComponent<Shooting>().currentWeapon;
        }
        else if(GameObject.Find("Player").GetComponent<Shooting>().currentWeapon == null)
        {
            GameObject.Find("WeaponSprite").GetComponent<RawImage>().color = Color.clear;
        }
    }

    public static void WeaponChange(Sprite newSprite)
    {
        RectTransform rt = GameObject.Find("WeaponSprite").GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2 (newSprite.rect.width * 2, newSprite.rect.height * 2);
        GameObject.Find("WeaponSprite").GetComponent<RawImage>().texture = newSprite.texture;
    }
}