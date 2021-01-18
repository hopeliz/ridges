using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GrabScreenInfo grabScreenInfo;
    public GameObject wholeScreenTarget;
    public GameObject contentContainer;

    public int buttonType = 0;
    // 0 - null
    // 1 - close
    // 2 - left
    // 3 - right
    // 4 - grow
    // 5 - shrink

    public void PressButton()
    {
        // Get references
        wholeScreenTarget = grabScreenInfo.wholeScreenObject;
        contentContainer = grabScreenInfo.contentContainer;

        switch (buttonType)
        {
            case 1:
                if (grabScreenInfo.isMenu)
                {
                    wholeScreenTarget.GetComponent<OpenCloseMenuBackground>().CloseMenu();
                }
                else
                {
                    wholeScreenTarget.GetComponent<OpenCloseScreen>().CloseScreen();
                }
                break;
            case 2:
                contentContainer.GetComponent<MenuContent>().GoBack();
                break;
            case 3:
                contentContainer.GetComponent<MenuContent>().GoForward();
                break;
            default:
                break;
        }
    }
}
