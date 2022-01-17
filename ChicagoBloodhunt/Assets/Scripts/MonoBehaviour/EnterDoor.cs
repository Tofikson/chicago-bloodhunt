using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    public Transform doorPos;           // trigger used to detect if player is in the door range
    public float width;                 // Width of the doorPos trigger
    public float height;                // height of the doorPos trigger

    public LayerMask playerLayer;       // LayerMask with player, used to detect if player is in range of the door      

    Vector2 targetPos;                  // Vector2 of where the player character should be located in the new scene after it loads.

    SceneSwitch sceneSwitch;            // Created to be able to change switch the scene

    [SerializeField] private string targetScene;    // Target scene that the doors lead to 
    [SerializeField] private float targetX;         // Target X where player is supposed to be located after the new scene loads
    [SerializeField] private float targetY;         // Target Y where player is supposed to be located after the new scene loads

    private void Start()
    {
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        targetPos = new Vector2(targetX, targetY);
    }

    void Update()
    {
        // If the Player Collider overlaps the Door Pos and if player presses the X button, then switch scene, while passing the target position
        if (Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, playerLayer) && Input.GetKeyDown(KeyCode.X))
        {
            sceneSwitch.SwitchSceneTargetPosition(targetScene, targetPos);
        }
    }

    // Debug, only to make my life easier in the editor
    // Display Gizmos of doorPos object in editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}
