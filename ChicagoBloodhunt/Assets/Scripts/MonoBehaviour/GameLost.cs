using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLost : MonoBehaviour
{
    public GameObject hp;
    public GameObject weapons;
    public GameObject antidote;
    public GameObject loseS;

    public bool gameLost = false;

    public void GameOverFunc()
    {
        hp.SetActive(false);
        weapons.SetActive(false);
        antidote.SetActive(false);
        loseS.SetActive(true);
        gameLost = true;
        Time.timeScale = 0f;
    }
}
