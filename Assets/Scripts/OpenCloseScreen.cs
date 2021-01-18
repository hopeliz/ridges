using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OpenCloseScreen : MonoBehaviour
{
    [Header("Script References")]
    public SelectionTargetBehavior selectionTargetBehavior;
    public GrabScreenInfo grabScreenInfo;

    [Header("Controller")]
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerPull;

    [Header("Menu Assets")]
    public Transform wholeScreenTarget;
    public Transform backgroundContainer;
    public GameObject contentContainer;
    public GameObject selectionTarget;

    [Header("Values")]
    public Vector3 screenFullSize;
    public Vector3 screenSmall;
    public float growSpeed = 1;
    public bool openingScreen = false;
    public bool closingScreen = false;
    public bool screenOpen = false;

    void Start()
    {
        // Get references
        wholeScreenTarget = grabScreenInfo.wholeScreenObject.transform;
        backgroundContainer = grabScreenInfo.backgroundContainer.transform;
        contentContainer = grabScreenInfo.contentContainer;

        // Initial setup
        screenFullSize = backgroundContainer.transform.localScale;
        screenSmall = new Vector3(backgroundContainer.localScale.x, backgroundContainer.localScale.y, 0.001F);
        backgroundContainer.transform.localScale = screenSmall;
        backgroundContainer.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (openingScreen)
        {
            if (backgroundContainer.localScale.z < screenFullSize.z)
            {
                backgroundContainer.localScale += Vector3.forward * Time.deltaTime * growSpeed;
            }
            else
            {
                openingScreen = false;
                screenOpen = true;
                selectionTarget.GetComponent<SelectionTargetBehavior>().currentScreen = wholeScreenTarget;
                contentContainer.SetActive(true);
            }
        }

        if (closingScreen)
        {
            if (backgroundContainer.localScale.z > 0.001F)
            {
                backgroundContainer.localScale += Vector3.back * Time.deltaTime;
            }
            else
            {
                closingScreen = false;
                screenOpen = false;
                selectionTarget.GetComponent<SelectionTargetBehavior>().currentScreen = null;
                backgroundContainer.gameObject.SetActive(false);
            }
        }

        // When trigger is pulled
        if (GetPull())
        {
            if (!screenOpen)
            {
                OpenScreen();
            }

            if (screenOpen)
            {
                // Checks for a button the target is on and "presses" it
                selectionTargetBehavior.buttonHighlighted.GetComponent<ButtonBehavior>().PressButton();
            }
        }
    }

    public void OpenScreen()
    {
        backgroundContainer.gameObject.SetActive(true);
        openingScreen = true;
    }

    public void CloseScreen()
    {
        contentContainer.SetActive(false);
        closingScreen = true;
    }

    public bool GetPull()
    {
        return triggerPull.GetStateDown(handType);
    }
}
