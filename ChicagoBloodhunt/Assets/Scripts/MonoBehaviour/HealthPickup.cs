using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPickup : MonoBehaviour
{

    public LayerMask playerLayer;   // Layer that the player is on
    public float width;             // Pickup collider width
    public float height;            // Pickup collider height

    public float healPower;

    private string sceneName;
    private string objectName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        objectName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapBox(gameObject.transform.position, new Vector2(width, height), 0, playerLayer))
        {
            if(GameObject.Find("Player").GetComponent<PlayerHealth>().currentHP < GameObject.Find("Player").GetComponent<PlayerHealth>().maxHp)
            {
                GameObject.Find("Player").GetComponent<PlayerHealth>().currentHP += healPower;

                DeletePickedUpObjects.instance.AddToList(sceneName, objectName);
                Destroy(gameObject);
                Debug.Log("first aid destroyed");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gameObject.transform.position, new Vector3(width, height, 1));
    }
}
