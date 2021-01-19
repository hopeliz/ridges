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
    public GameObject buttonHighlighted = null;
    
    void Start()
    {
        fullSize = transform.localScale;
        currentScreen = null;
    }

    public void OnTriggerStay(Collider other)
    {
        print("Target is hitting this: " + other.transform.name);

        if (other.gameObject != null)
        {
            if (other.gameObject.layer == 11)
            {
                buttonHighlighted = other.gameObject;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            buttonHighlighted = null;
        }
    }

    public bool GetGrab()
    {
        return triggerPull.GetState(handType);
    }
}
