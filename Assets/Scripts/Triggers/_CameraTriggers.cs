using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CameraTriggers : MonoBehaviour
{
    public GameObject tempDoor = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 3)) {
            if (hitInfo.transform.tag == "Door")
            {
                // Store door temporarily
                tempDoor = hitInfo.transform.gameObject;

                // Show prompts when looking at door or knob
                hitInfo.transform.GetComponent<DoorBehavior>().showPrompts = true;
            }
            
            if (hitInfo.transform.tag != "Door")
            {
                if (tempDoor != null)
                {
                    // Turn off prompts to most recent door
                    tempDoor.GetComponent<DoorBehavior>().showPrompts = false;

                    // Reset temp door
                    tempDoor = null;
                }
            } 
        }
    }
}
