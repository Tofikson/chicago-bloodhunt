using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntidoteUi : MonoBehaviour
{
    public Animator a1;
    public Animator a2;

    public void UiAntidoteUse()
    {
        int aCount = GameObject.Find("Player").GetComponent<AntidoteScript>().currentAntidote;

        switch(aCount)
        {
            case 0:
                a1.SetBool("Full", false);
                a2.SetBool("Full", false);
                break;
            case 1:
                a1.SetBool("Full", true);
                a2.SetBool("Full", false);
                break;
            case 2:
                a1.SetBool("Full", true);
                a2.SetBool("Full", true);
                break;
        }

    }
}
