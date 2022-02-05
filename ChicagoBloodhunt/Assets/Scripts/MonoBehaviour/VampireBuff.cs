using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireBuff : MonoBehaviour
{
    public bool vampBuff = false;
    public float speedBuff;
    public float jumpBuff;
    public float durationLenght;
    public float duration = 0f;
    public RuntimeAnimatorController vampAnim;

    [System.NonSerialized] public bool buffStarted = false;
    [System.NonSerialized] public float normalSpeed;
    [System.NonSerialized] public float normalJump;
    [System.NonSerialized] public Weapon lastWeapon;
    private WeaponUI weaponUi;

    private void Start()
    {
        normalSpeed = gameObject.GetComponent<CharacterMovement>().speed;
        normalJump = gameObject.GetComponent<CharacterMovement>().jumpForce;
        weaponUi = GameObject.Find("WeaponSprite").GetComponent<WeaponUI>();
    }

    public void ActivateVampBuff()
    {
        vampBuff = true;
    }

    public void IsGameOver()
    {
        if (gameObject.GetComponent<AntidoteScript>().UseAntidote())
        {
            Debug.Log("Continue");
            gameObject.GetComponent<PlayerHealth>().currentHP += 20f;
        }
        else
        {
            Debug.Log("Die");
            GameObject.Find("SceneSwitch").GetComponent<GameLost>().GameOverFunc();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!vampBuff) return;

        if(!buffStarted)
        {
            buffStarted = true;
            lastWeapon = gameObject.GetComponent<Shooting>().currentWeapon;
            gameObject.GetComponent<Shooting>().currentWeapon = null;
            GameObject.Find("PlayerGFX").GetComponent<Animator>().runtimeAnimatorController = vampAnim;
            gameObject.GetComponent<CharacterMovement>().speed += speedBuff;
            gameObject.GetComponent<CharacterMovement>().jumpForce += jumpBuff;
        }
        duration += Time.deltaTime;



        if (duration >= durationLenght)
        {
            gameObject.GetComponent<CharacterMovement>().speed = normalSpeed;
            gameObject.GetComponent<CharacterMovement>().jumpForce = normalJump;
            gameObject.GetComponent<Shooting>().currentWeapon = lastWeapon;
            weaponUi.WeaponChange(lastWeapon.icon);
            GameObject.Find("PlayerGFX").GetComponent<Animator>().runtimeAnimatorController = lastWeapon.animatorController;
            vampBuff = false;
            buffStarted = false;
            duration = 0f;
            IsGameOver();
        }
    }
}
