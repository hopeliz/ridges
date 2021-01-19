using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FarMenuFunctions : MonoBehaviour
{
    [Header("Script References")]
    [Tooltip("This will change based on where target hits.")]
    public GrabScreenInfo grabScreenInfo;

    [Header("Controller")]
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerPull;
    public GameObject rightBall;

    [Header("Menu Assets")]
    public GameObject wholeScreenTarget;
    public GameObject contentContainer;
    //public GameObject resizeButtons;
    //public GameObject closeButton;
    //public GameObject rightButton;
    //public GameObject leftButton;
    //public GameObject growButton;
    //public GameObject shrinkButton;
    //public Vector3 originalPostion;

    [Header("Target")]
    public GameObject selectionTarget;

    private void Start()
    {
        // Get references
        grabScreenInfo = null;
    }

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

            // Set Grab Screen Info if it's avalable
            if (hit.transform.GetComponent<GrabScreenInfo>() != null)
            {
                grabScreenInfo = hit.transform.GetComponent<GrabScreenInfo>();
            }

            if (grabScreenInfo != null)
            {
                wholeScreenTarget = grabScreenInfo.wholeScreenObject;
                contentContainer = grabScreenInfo.contentContainer;

                // If it's a menu
                if (wholeScreenTarget.GetComponent<OpenCloseMenuBackground>() != null)
                {
                    // If the menu is open
                    if (wholeScreenTarget.GetComponent<OpenCloseMenuBackground>().menuOpen)
                    {
                        selectionTarget.SetActive(true);
                        selectionTarget.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z - 0.04F);
                        selectionTarget.transform.eulerAngles = wholeScreenTarget.transform.eulerAngles;
                    }
                }

                // If it's a screen
                if (wholeScreenTarget.GetComponent<OpenCloseScreen>() != null)
                {
                    // If the screen is open
                    if (wholeScreenTarget.GetComponent<OpenCloseScreen>().screenOpen)
                    {
                        selectionTarget.SetActive(true);
                        selectionTarget.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z - 0.04F);
                        selectionTarget.transform.eulerAngles = wholeScreenTarget.transform.eulerAngles;
                    }
                }
            }
        }
        else
        {
            grabScreenInfo = null;
            selectionTarget.GetComponent<SelectionTargetBehavior>().buttonHighlighted = null;
            selectionTarget.SetActive(false);
            print("Not hitting things.");
        }
    }
}
