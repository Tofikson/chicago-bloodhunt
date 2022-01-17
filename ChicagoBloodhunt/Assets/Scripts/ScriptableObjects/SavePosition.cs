using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// !!!------------------------------------------------------------------------------!!!
//      Use only to save player target location in different Scene !!!
//      It may be changed if we'll need to store some other data than only position
// !!!------------------------------------------------------------------------------!!!


public class SavePosition : ScriptableObject 
{
    public static Vector2 position; // Position to be saved

    // Function to be called if the position is supposed to be saved between scenes
    public static void Save(Vector2 pos)
    {
        position = pos;
    }

    // Function to be called if the position is supposed to be loaded to the active scene
    public static Vector2 Load()
    {
        return position;
    }
}
