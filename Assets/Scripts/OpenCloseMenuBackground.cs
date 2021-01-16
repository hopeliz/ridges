﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OpenCloseMenuBackground : MonoBehaviour
{
    [Header("Other Scripts")]
    public MenuSafety menuSafety;

    [Header("Controller")]
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerPull;
    public SteamVR_Action_Boolean joystickRight;
    public SteamVR_Action_Boolean joystickLeft;

    [Header("Menu Assets")]
    public Transform menuTargetObject;
    public Transform menuBackgroundContainer;
    public GameObject menuContentContainer;
    public Material menuTargetMaterial;
    public Material menuRectangle;
    public Vector3 menuFullSize;
    public Vector3 menuSmall;

    [Header("Values")]
    public float growSpeed = 1;
    public bool openingMenu = false;
    public bool closingMenu = false;
    public bool menuOpen = false;

    void Start()
    {
        menuFullSize = menuBackgroundContainer.localScale;
        menuSmall = new Vector3(menuBackgroundContainer.localScale.x, menuBackgroundContainer.localScale.y, 0.001F);
        menuBackgroundContainer.localScale = menuSmall;
        menuBackgroundContainer.gameObject.SetActive(false);
    }

    void Update()
    {
        if (openingMenu)
        {
            if (menuBackgroundContainer.localScale.z < menuFullSize.z)
            {
                menuBackgroundContainer.localScale += Vector3.forward * Time.deltaTime * growSpeed;
            }
            else
            {
                openingMenu = false;
                menuOpen = true;
                menuContentContainer.SetActive(true);
            }
        }

        if (closingMenu)
        {
            if (menuBackgroundContainer.localScale.z > 0.001F)
            {
                menuBackgroundContainer.localScale += Vector3.back * Time.deltaTime;
            }
            else
            {
                closingMenu = false;
                menuOpen = false;
                menuBackgroundContainer.gameObject.SetActive(false);
                transform.GetComponent<Renderer>().material = menuTargetMaterial;
            }
        }

        if (GetPull())
        {
            print("Open");
            OpenMenu();
        }

        if (GetEast())
        {
            menuTargetObject.eulerAngles += Vector3.up * menuTargetObject.GetComponent<TargetHeight>().rotateSpeed * Time.deltaTime;
        }

        if (GetWest())
        {
            menuTargetObject.eulerAngles += Vector3.down * menuTargetObject.GetComponent<TargetHeight>().rotateSpeed * Time.deltaTime;
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
            menuBackgroundContainer.gameObject.SetActive(true);
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
        menuContentContainer.SetActive(false);
        closingMenu = true;
    }

    public bool GetPull()
    {
        return triggerPull.GetState(handType);
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