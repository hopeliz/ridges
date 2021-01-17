using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FarMenuFunctions : MonoBehaviour
{
    [Header("Controller")]
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerPull;
    public GameObject rightBall;

    [Header("Menu Assets")]
    public GameObject menuTarget;
    public GameObject menuContentContainer;
    public GameObject resizeButtons;
    public GameObject closeButton;
    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject growButton;
    public GameObject shrinkButton;
    public Vector3 originalPostion;

    [Header("Target")]
    public GameObject selectionTarget;

    [Header("Interactions")]
    
    public int currentInteration = 0;   // Zero is no button, just moves
    
    void Update()
    {
        print("test");
        int layerMask = 1 << 10;
        //int layerMask = 1 << 9;
        //layerMask = ~layerMask;

        // If ray hits something
        if (Physics.Raycast(rightBall.transform.position, rightBall.transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            print("Right hand menu ray hit: " + hit.transform.name);

            // If the menu is open
            if (menuTarget.GetComponent<OpenCloseMenuBackground>().menuOpen)
            {
                selectionTarget.SetActive(true);
                selectionTarget.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z - 0.05F);
                selectionTarget.transform.eulerAngles = menuTarget.transform.eulerAngles;
            }
        }
        else
        {
            selectionTarget.SetActive(false);
            print("Not hitting things.");
        }

        if (GetGrab())
        {
            if (currentInteration == 1)
            {
                menuTarget.GetComponent<OpenCloseMenuBackground>().CloseMenu();
            }

            if (currentInteration == 2)
            {
                menuContentContainer.GetComponent<MenuContent>().GoBack();
            }

            if (currentInteration == 3)
            {
                menuContentContainer.GetComponent<MenuContent>().GoForward();
            }

            if (currentInteration == 4)
            {
                resizeButtons.GetComponent<ResizeMenu>().Grow();
            }

            if (currentInteration == 5)
            {
                resizeButtons.GetComponent<ResizeMenu>().Shrink();
            }
        }
    }

    public bool GetGrab()
    {
        return triggerPull.GetState(handType);
    }
}
