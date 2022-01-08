using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour // Script used to load new scene
{
    Vector2 targetPos;

    public virtual void Start()
    {
        // when the new scene is loaded, character position and camera position is set to one stored in SavePosition.cs Vector2 position
        GameObject.Find("Player").transform.position = SavePosition.Load();
    }

    // Used to switch scene to one with SceneName
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Used to switch scene while saving the targetPosition Vector2
    public void SwitchSceneTargetPosition(string sceneName, Vector2 targetPosition)
    {
        SceneManager.LoadScene(sceneName);
        SavePosition.Save(targetPosition);
    }
}
