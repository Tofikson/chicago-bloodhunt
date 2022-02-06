using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VampireBuff : MonoBehaviour
{
    public bool vampBuff = false;
    public float speedBuff;
    public float jumpBuff;
    public float durationLenght;
    public float duration = 0f;
    public RuntimeAnimatorController vampAnim;
    public float cooldownDuration;
    public float currentCooldown;

    [System.NonSerialized] public bool buffStarted = false;
    [System.NonSerialized] public float normalSpeed;
    [System.NonSerialized] public float normalJump;
    [System.NonSerialized] public Weapon lastWeapon;
    private WeaponUI weaponUi;
    public RuntimeAnimatorController noWeapon;

    private void Start()
    {
        SaveVampState.LoadVamp();

        weaponUi = GameObject.Find("WeaponSprite").GetComponent<WeaponUI>();

        if (buffStarted && vampBuff)
        {
            EnterVampBuff();
            return;
        }

        normalSpeed = gameObject.GetComponent<CharacterMovement>().speed;
        normalJump = gameObject.GetComponent<CharacterMovement>().jumpForce;
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

    public void VampFormAnimation()
    {
        if(vampBuff)
        {
            GameObject.Find("PlayerGFX").GetComponent<Animator>().runtimeAnimatorController = vampAnim;
        }
    }

    public void ExitVampBuff()
    {
        gameObject.GetComponent<CharacterMovement>().speed = normalSpeed;
        gameObject.GetComponent<CharacterMovement>().jumpForce = normalJump;
        GameObject.Find("VampAttack").GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("PlayerGFX").GetComponent<Animator>().SetBool("Attacking", false);
        if (lastWeapon == null)
        {
            gameObject.GetComponent<Shooting>().currentWeapon = WeaponsInventory.instance.weapons[0];
            GameObject.Find("PlayerGFX").GetComponent<Animator>().runtimeAnimatorController = WeaponsInventory.instance.weapons[0].animatorController;
            weaponUi.WeaponChange(WeaponsInventory.instance.weapons[0].icon);
        }
        else
        {
            gameObject.GetComponent<Shooting>().currentWeapon = lastWeapon;
            weaponUi.WeaponChange(lastWeapon.icon);
            GameObject.Find("PlayerGFX").GetComponent<Animator>().runtimeAnimatorController = lastWeapon.animatorController;
        }
        vampBuff = false;
        buffStarted = false;
        duration = 0f;
        IsGameOver();
    }

    public void EnterVampBuff()
    {
        buffStarted = true;
        lastWeapon = gameObject.GetComponent<Shooting>().currentWeapon;
        gameObject.GetComponent<Shooting>().currentWeapon = null;
        GameObject.Find("PlayerGFX").GetComponent<Animator>().runtimeAnimatorController = vampAnim;
        gameObject.GetComponent<CharacterMovement>().speed += speedBuff;
        gameObject.GetComponent<CharacterMovement>().jumpForce += jumpBuff;
    }

    private void VampAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            GameObject.Find("VampAttack").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("PlayerGFX").GetComponent<Animator>().SetBool("Attacking", true);
        }
        else
        {
            GameObject.Find("VampAttack").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("PlayerGFX").GetComponent<Animator>().SetBool("Attacking", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!vampBuff) return;

        if(!buffStarted)
        {
            EnterVampBuff();
        }

        duration += Time.deltaTime;

        VampAttack();

        if (duration >= durationLenght)
        {
            ExitVampBuff();
        }
    }
}
