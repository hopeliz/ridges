using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

    public class GrabPaintRoller : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;
    public GameObject gameMasterObject;
    public bool hasItem = false;
    public Vector3 originalLocation;
    public Vector3 originalRotation;

    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetGrab()
    {
        return grabAction.GetState(handType);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Paint Roller")
        {
            if (GetGrab())
            {
                originalLocation = other.transform.position;
                originalRotation = other.transform.eulerAngles;

                other.gameObject.transform.parent = transform;
                hasItem = true;
            }

            if (!GetGrab())
            {
                if (hasItem)
                {
                    other.gameObject.transform.parent = gameMasterObject.transform;

                    if (originalLocation != null && originalRotation != null)
                    {
                        other.transform.position = originalLocation;
                        other.transform.eulerAngles = originalRotation;
                    }
                }
            }
        }
    }
}
