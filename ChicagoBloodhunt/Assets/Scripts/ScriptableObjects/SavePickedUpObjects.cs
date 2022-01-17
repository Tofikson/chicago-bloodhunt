using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePickedUpObjects : ScriptableObject
{
    private static List<PickedUpObject> pickUpObj = new List<PickedUpObject>();

    public static void Save()
    {
        pickUpObj = DeletePickedUpObjects.instance.pickUpObj;
    }

    public static void Load()
    {
        DeletePickedUpObjects.instance.pickUpObj = pickUpObj;
    }
}
