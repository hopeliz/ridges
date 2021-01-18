using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SelectionTargetBehavior : MonoBehaviour
{
    [Header("Controller")]
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerPull;
    public GameObject rightBall;

    [Header("Target")]
    public GameObject selectionTargetContainer;
    public Vector3 fullSize;
    public Vector3 selectedSize;
    public bool isHeld = false;
    public float shrinkSpeed = 0.1F;

    [Header("Interaction")]
    public Transform currentScreen;
    public GameObject buttonHighlighted;
    
    void Start()
    {
        fullSize = transform.localScale;
        currentScreen = null;
    }

    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        print("Target is hitting this: " + other.transform.name);

        buttonHighlighted = other.gameObject;
        /**
        if (GetGrab())
        {
            print("pressing close");
            currentScreen.GetComponent<OpenCloseMenuBackground>().CloseMenu();
        }
        **/

    /**
    if (currentScreen.name == "Menu Target")
    {
        switch (other.transform.name)
        {
            case "Close Button":
                selectionTargetContainer.GetComponent<FarMenuFunctions>().currentInteration = 1;
                break;
            case "Left Button":
                selectionTargetContainer.GetComponent<FarMenuFunctions>().currentInteration = 2;
                break;
            case "Right Button":
                selectionTargetContainer.GetComponent<FarMenuFunctions>().currentInteration = 3;
                break;
            case "Grow Button":
                selectionTargetContainer.GetComponent<FarMenuFunctions>().currentInteration = 4;
                break;
            case "Shrink Button":
                selectionTargetContainer.GetComponent<FarMenuFunctions>().currentInteration = 5;
                break;
            default:
                selectionTargetContainer.GetComponent<FarMenuFunctions>().currentInteration = 0;
                break;
        }
    }
    **/
    }

    public bool GetGrab()
    {
        return triggerPull.GetState(handType);
    }
}
