using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GrabScreenInfo grabScreenInfo;
    public bool isMenu = false;

    public void ButtonFunction()
    {
        if (isMenu)
        {
            grabScreenInfo.wholeScreenObject.GetComponent<OpenCloseMenuBackground>().CloseMenu();
        }
        else
        {
            grabScreenInfo.wholeScreenObject.GetComponent<OpenCloseScreen>().CloseScreen();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        print("Something is touching the close button: " + other.gameObject.name);

        if (other.gameObject.tag == "Controller")
        {
            ButtonFunction();
        }
    }
}
