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
    
    void Start()
    {
        
    }
    
    void Update()
    {
        // If ray hits something
        if (Physics.Raycast(rightBall.transform.position, rightBall.transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, 10))
        {
            // If the menu is open
            if (menuTarget.GetComponent<OpenCloseMenuBackground>().menuOpen)
            {
                // If the thing the ray hits is a screen or button
                if (hit.transform.tag == "Screen" || hit.transform.tag == "Button")
                {
                    // Turn on selection target object and place it where the ray hits
                    selectionTarget.SetActive(true);
                    selectionTarget.transform.position = hit.point;
                }
                // Otherwise, turn off selection target object
                else
                {
                    selectionTarget.SetActive(false);
                }
            }
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
