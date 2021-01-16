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
        
    }

    public bool GetTeleportDown()
    {
        return teleportAction.GetStateDown(handType);
    }

    public bool GetGrab()
    {
        return grabAction.GetState(handType);
    }
}
