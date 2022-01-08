using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layerFellOutOfMap : MonoBehaviour
{
    // Debug script, just in case the player somehow falls out of the scene

    void Update()
    {
        if (gameObject.transform.position.y < -10f)
            gameObject.transform.position = Vector3.zero;
    }
}
