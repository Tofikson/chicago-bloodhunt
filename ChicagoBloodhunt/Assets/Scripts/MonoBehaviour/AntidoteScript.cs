using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntidoteScript : MonoBehaviour
{
    public int maxAntidote;
    public int currentAntidote;
    public AntidoteUi ui;

    private void Start()
    {
        if (ui == null)
        {
            ui = GameObject.Find("Antidote").GetComponent<AntidoteUi>();
        }
        currentAntidote = SaveCurrentHP.LoadAntidote();
        ui.UiAntidoteUse();
    }

    public void GetAntidote()
    {
        if(currentAntidote < maxAntidote)
        {
            currentAntidote++;
            ui.UiAntidoteUse();
        }
    }

    public bool UseAntidote() // If player has antidote, then remove one and return true. If not, return false.
    {
        
        if (currentAntidote <= 0)
        {
            Debug.Log("No antidote, you die");
            return false;
        }

        currentAntidote--;
        ui.UiAntidoteUse();
        return true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            GetAntidote();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            UseAntidote();
        }
    }
}
