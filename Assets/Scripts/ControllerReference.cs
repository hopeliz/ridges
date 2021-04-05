using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerReference : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean gripAction;
    //public SteamVR_Action_Boolean goForwardAction;
    //public SteamVR_Action_Boolean goBackAction;
    public SteamVR_Action_Boolean goLeftAction;
    public SteamVR_Action_Boolean goRightAction;
    public bool leftHand;

    //public SteamVR_Action_Single squeezeAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Gets current states of controller buttons
    public bool GetGrab()
    {
        return grabAction.GetState(handType);
    }

    public bool GetGrabDown()
    {
        return grabAction.GetStateDown(handType);
    }

    public bool GetGrip()
    {
        return gripAction.GetState(handType);
    }
    /*
    public bool GetForward()
    {
        return goForwardAction.GetState(handType);
    }

    public bool GetBack()
    {
        return goBackAction.GetState(handType);
    }
    */
    public bool GetLeft()
    {
        return goLeftAction.GetState(handType);
    }

    public bool GetRight()
    {
        return goRightAction.GetState(handType);
    }
}
