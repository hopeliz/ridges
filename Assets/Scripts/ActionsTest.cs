using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionsTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean teleportAction;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Single squeezeAction;
    public SteamVR_Action_Boolean goForwardAction;
    public SteamVR_Action_Boolean goBackAction;
    public SteamVR_Action_Boolean goLeftAction;
    public SteamVR_Action_Boolean goRightAction;

    void Update()
    {
        if (GetTeleportDown())
        {
            print("Teleport: " + handType);
        }

        if (GetGrab())
        {
            print("Grab: " + handType);
            print("Grab amount: " + squeezeAction.GetAxis(handType));
        }

        if (GetGoBack())
        {
            print("Go back");
        }

        if (GetGoForward())
        {
            print("Go forward");
        }

        if (GetGoLeft())
        {
            print("Go left");
        }

        if (GetGoRight())
        {
            print("Go right");
        }

    }

    public bool GetTeleportDown()
    {
        return teleportAction.GetStateDown(handType);
    }

    public bool GetGrab()
    {
        return grabAction.GetState(handType);
    }

    public bool GetGoForward()
    {
        return goForwardAction.GetState(handType);
    }

    public bool GetGoBack()
    {
        return goBackAction.GetState(handType);
    }

    public bool GetGoLeft()
    {
        return goLeftAction.GetState(handType);
    }

    public bool GetGoRight()
    {
        return goRightAction.GetState(handType);
    }


}
