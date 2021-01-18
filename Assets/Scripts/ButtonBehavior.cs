using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject menuTarget;
    public GameObject menuContentContainer;

    public int buttonType = 0;
    // 0 - null
    // 1 - close
    // 2 - left
    // 3 - right
    // 4 - grow
    // 5 - shrink

    public void PressButton()
    {
        switch (buttonType)
        {
            case 1:
                menuTarget.GetComponent<OpenCloseMenuBackground>().CloseMenu();
                break;
            case 2:
                menuContentContainer.GetComponent<MenuContent>().GoBack();
                break;
            case 3:
                menuContentContainer.GetComponent<MenuContent>().GoForward();
                break;
            default:
                break;
        }
    }
}
