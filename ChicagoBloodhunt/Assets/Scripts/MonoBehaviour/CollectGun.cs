using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectGun : MonoBehaviour
{
    public Weapon weapon;           // Weapon that is in a pickup
    public LayerMask playerLayer;   // Layer that the player is on
    public float width;             // Pickup collider width
    public float height;            // Pickup collider height

    private string sceneName;
    private string objectName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        objectName = gameObject.name;
    }

    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<VampireBuff>().vampBuff) return;

        // If player collides with weapon collider, then pick up the weapon and destroy pickup
        if (Physics2D.OverlapBox(gameObject.transform.position, new Vector2(width, height), 0, playerLayer))
        {
            WeaponsInventory.instance.Add(weapon);

            // If player doesn't have the weapon equiped, use the one he has just picked up
            if(GameObject.Find("Player").GetComponent<Shooting>().currentWeapon == null)
            {
                GameObject.Find("Player").GetComponent<Shooting>().currentWeapon = weapon;
                GameObject.Find("PlayerGFX").GetComponent<Animator>().runtimeAnimatorController = weapon.animatorController;
            }

            Debug.Log("Picked " + weapon.name);

            DeletePickedUpObjects.instance.AddToList(sceneName, objectName);
            Destroy(gameObject);
        }
    }

    private void OnValidate()
    {
        this.transform.Find("WeaponPickupGFX").GetComponent<SpriteRenderer>().sprite = weapon.icon;
    }

    // Debug, only to make my life easier in the editor
    // Display Gizmos of doorPos object in editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(gameObject.transform.position, new Vector3(width, height, 1));
    }

}
