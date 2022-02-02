using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour // Script used to load new scene
{
    public Animator transition;

    public virtual void Start()
    {
        // when the new scene is loaded, character position and camera position is set to one stored in SavePosition.cs Vector2 position
        GameObject.Find("Player").transform.position = SavePosition.Load();
        SaveWeapons.Load();
        SavePickedUpObjects.Load();
        DeletePickedUpObjects.instance.RemoveObjectsFromScene();
    }

    // Used to switch scene to one with SceneName
    public void SwitchScene(string sceneName)
    {
        StartCoroutine(AnimationCoroutine(sceneName));
    }

    // Used to switch scene while saving the targetPosition Vector2
    public void SwitchSceneTargetPosition(string sceneName, Vector2 targetPosition)
    {
        SavePosition.Save(targetPosition);
        SaveWeapons.Save();
        SaveCurrentHP.SaveHP(GameObject.Find("Player").GetComponent<PlayerHealth>().currentHP);
        SavePickedUpObjects.Save();

        Time.timeScale = 0f;
        StartCoroutine(AnimationCoroutine(sceneName));
    }

    IEnumerator AnimationCoroutine(string sceneName)
    {
        transition.SetTrigger("Play");

        yield return new WaitForSecondsRealtime(.5f);

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
