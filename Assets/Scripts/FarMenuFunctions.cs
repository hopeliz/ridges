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
    public GameObject target;
    public Vector3 targetFullSize;
    public Vector3 selectedSize;
    public float yOffset = 0;
    public bool isHeld = false;
    public float targetShrinkSpeed = 0.1F;

    [Header("Interactions")]
    public int currentInteration = 0;   // Zero is no button, just moves
    
    void Start()
    {
        targetFullSize = target.transform.localScale;
    }
    
    void Update()
    {
        if (Physics.Raycast(rightBall.transform.position, rightBall.transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, 10))
        {
            if (menuTarget.GetComponent<OpenCloseMenuBackground>().menuOpen)
            {
                target.transform.position = hit.point;
            }
        }

        if (GetGrab())
        {

            if (target.transform.localScale.x >= targetFullSize.x/2)
            {
                target.transform.localScale *= targetShrinkSpeed * Time.deltaTime;
            }

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

            // Work on this!!
            /*
            if (currentInteration == 0)
            {
                if (!isHeld)
                {
                    yOffset = hit.point.y - menuTarget.GetComponent<TargetHeight>().menuHeight;
                    isHeld = true;
                }
                else
                {
                    menuTarget.GetComponent<TargetHeight>().menuHeight = hit.point.y + yOffset;
                }
            }
            */
        }

        if (!GetGrab())
        {
            isHeld = false;

            if (target.transform.localScale.x < targetFullSize.x)
            {
                target.transform.localScale /= targetShrinkSpeed * Time.deltaTime;
            }
        }
    }

    public bool GetGrab()
    {
        return triggerPull.GetState(handType);
    }

    public void OnTriggerStay(Collider other)
    {
        switch (other.transform.name)
        {
            case "Close Button":
                currentInteration = 1;
                break;
            case "Left Button":
                currentInteration = 2;
                break;
            case "Right Button":
                currentInteration = 3;
                break;
            case "Grow Button":
                currentInteration = 4;
                break;
            case "Shrink Button":
                currentInteration = 5;
                break;
            default:
                currentInteration = 0;
                break;
        }
    }
}
