using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 targetPosition;             // vector 3 used to calculate the position that the camera needs to be to follow the player
    private Vector3 velocity = Vector3.zero;    // targer velocity of camera when player is not moving
    private float cameraY;                      // vertical position of camera, used to lock camera movements below the 0 on Y axis

    [SerializeField] float smoothing = 0.01f;   // factor by which camera movements are smoothed

    private void Start()
    {
        gameObject.transform.position = new Vector3(SavePosition.Load().x, SavePosition.Load().y + 1.5f , -10);
    }

    void FixedUpdate()
    {

        // Lock camera movement to 0 if player went below the 0 on Y axis,
        if(GameObject.Find("Player").transform.position.y <= 0f)
        {
            cameraY = 0f;
        }
        else
        {
            cameraY = GameObject.Find("Player").transform.position.y;
        }

        // Calculate the target position of camera with the constraint applied
        targetPosition = new Vector3(GameObject.Find("Player").transform.position.x, cameraY, gameObject.transform.position.z);

        // Apply camera position and smooth it with SmoothDamp
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition, ref velocity, smoothing);
    }
}
