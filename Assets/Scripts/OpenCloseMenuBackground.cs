using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OpenCloseMenuBackground : MonoBehaviour
{
    [Header("Script References")]
    public MenuSafety menuSafety;
    public SelectionTargetBehavior selectionTargetBehavior;
    public GrabScreenInfo grabScreenInfo;


    [Header("Controller")]
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerPull;
    public SteamVR_Action_Boolean joystickRight;
    public SteamVR_Action_Boolean joystickLeft;

    [Header("Menu Assets")]
    public Transform wholeScreenTarget;
    public Transform backgroundContainer;
    public GameObject contentContainer;
    public GameObject menuSafetyBox;
    public Material menuTargetMaterial;
    public Material menuRectangle;
    public Vector3 menuFullSize;
    public Vector3 menuSmall;
    public GameObject selectionTarget;

    [Header("Values")]
    public float growSpeed = 1;
    public bool openingMenu = false;
    public bool closingMenu = false;
    public bool menuOpen = false;

    void Start()
    {
        // Get references
        wholeScreenTarget = grabScreenInfo.wholeScreenObject.transform;
        backgroundContainer = grabScreenInfo.backgroundContainer.transform;
        contentContainer = grabScreenInfo.contentContainer;

        // Initial settings
        menuFullSize = backgroundContainer.localScale;
        menuSmall = new Vector3(backgroundContainer.localScale.x, backgroundContainer.localScale.y, 0.001F);
        backgroundContainer.localScale = menuSmall;
        backgroundContainer.gameObject.SetActive(false);
    }

    void Update()
    {
        if (openingMenu)
        {
            if (backgroundContainer.localScale.z < menuFullSize.z)
            {
                backgroundContainer.localScale += Vector3.forward * Time.deltaTime * growSpeed;
            }
            else
            {
                openingMenu = false;
                menuOpen = true;
                menuSafetyBox.SetActive(false);
                selectionTarget.GetComponent<SelectionTargetBehavior>().currentScreen = wholeScreenTarget;
                contentContainer.SetActive(true);
            }
        }

        if (closingMenu)
        {
            if (backgroundContainer.localScale.z > 0.001F)
            {
                backgroundContainer.localScale += Vector3.back * Time.deltaTime;
            }
            else
            {
                closingMenu = false;
                menuOpen = false;
                menuSafetyBox.SetActive(true);
                selectionTarget.GetComponent<SelectionTargetBehavior>().currentScreen = null;
                backgroundContainer.gameObject.SetActive(false);
                transform.GetComponent<Renderer>().material = menuTargetMaterial;
            }
        }

        if (GetPull())
        {
            if (!menuOpen)
            {
                print("Open");
                OpenMenu();
            }

            if (menuOpen)
            {
                print("Try to close");
                selectionTargetBehavior.buttonHighlighted.GetComponent<ButtonBehavior>().PressButton();
            }
        }

        if (GetEast())
        {
            wholeScreenTarget.eulerAngles += Vector3.up * wholeScreenTarget.GetComponent<TargetHeight>().rotateSpeed * Time.deltaTime;
        }

        if (GetWest())
        {
            wholeScreenTarget.eulerAngles += Vector3.down * wholeScreenTarget.GetComponent<TargetHeight>().rotateSpeed * Time.deltaTime;
        }

        // KEYBOARD SHORTCUTS FOR TESTING
        if (Input.GetKeyDown(KeyCode.O))
        {
            print("Open");
            OpenMenu();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            print("Close");
            CloseMenu();
        }
        // End Keyboard shortcuts
    }

    public void OpenMenu()
    {
        if (menuSafety.safeMenu)
        {
            backgroundContainer.gameObject.SetActive(true);
            transform.GetComponent<Renderer>().material = menuRectangle;
            openingMenu = true;
        }
        else
        {
            print("Cannot open menu here.");
        }
    }

    public void CloseMenu()
    {
        contentContainer.SetActive(false);
        closingMenu = true;
    }

    public bool GetPull()
    {
        return triggerPull.GetStateDown(handType);
    }

    public bool GetEast()
    {
        return joystickRight.GetState(handType);
    }

    public bool GetWest()
    {
        return joystickLeft.GetState(handType);
    }
}
