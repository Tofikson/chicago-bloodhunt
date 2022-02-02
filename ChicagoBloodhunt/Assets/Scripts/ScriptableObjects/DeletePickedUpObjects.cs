using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class representing object info needed to delete it from new scene
public class PickedUpObject
{
    public string sName { get; set; } // Scene name at which the object exists
    public string oName { get; set; } // Object name which is supposed to be destroyed

    public PickedUpObject(string sceneName, string objectName) // constructor
    {
        sName = sceneName;
        oName = objectName;
    }
}

public class DeletePickedUpObjects : MonoBehaviour
{
    #region Singleton
    public static DeletePickedUpObjects instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one DeletePickedUpObjects instance");
        }
        instance = this;
    }
    #endregion

    public List<PickedUpObject> pickUpObj = new List<PickedUpObject>(); // List of objects that are supposed to be destroyed when opening new scene

    // Function that allows adding new object to the list
    // There is no function that deletes item from list. since it won't be needed
    public void AddToList(string sceneName, string objectName)
    {
        pickUpObj.Add(new PickedUpObject(sceneName, objectName));
    }

    // Function that destroys object in scene based on what is in the list
    public void RemoveObjectsFromScene()
    {
        foreach( PickedUpObject obj in pickUpObj)
        {
            if(obj.sName == SceneManager.GetActiveScene().name)
            {
                Debug.Log("Destroyed object "+obj.oName);
                Destroy(GameObject.Find(obj.oName));
            }
        }
    }
}
