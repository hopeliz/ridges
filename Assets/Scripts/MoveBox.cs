using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MoveBox : MonoBehaviour
{
    [Header("Controller")]
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerPull;
    public SteamVR_Action_Single squeezeAmount;

    [Header("Movement")]
    public GameObject leftSphere;
    public float moveSpeed;
    public GameObject vrSpace;
    public GameObject cameraObject;
    public int directionFacing;
    
    void Update()
    {
        if (GetPull())
        {
            print("Trigger Pulled.");
        }

        Debug.DrawRay(leftSphere.transform.position, leftSphere.transform.TransformDirection(Vector3.forward), Color.black);

        if (Physics.Raycast(cameraObject.transform.position, cameraObject.transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.transform.name == "Forward") { directionFacing = 0; }

            if (hit.transform.name == "Right") { directionFacing = 1; }

            if (hit.transform.name == "Back") { directionFacing = 2; }

            if (hit.transform.name == "Left") { directionFacing = 3; }
        }

        if (Physics.Raycast(leftSphere.transform.position, leftSphere.transform.TransformDirection(Vector3.forward), out RaycastHit hit1, Mathf.Infinity))
        {
            if (hit1.transform.name == "Forward" && GetPull())
            {
                MoveForward();
            }

            if (hit1.transform.name == "Right" && GetPull())
            {
                MoveRight();
            }

            if (hit1.transform.name == "Back" && GetPull())
            {
                MoveBack();
            }

            if (hit1.transform.name == "Left" && GetPull())
            {
                MoveLeft();
            }

            if (hit1.transform.name == "Top" && GetPull())
            {
                switch (directionFacing)
                {
                    case 0:
                        MoveBack();
                        break;
                    case 1:
                        MoveLeft();
                        break;
                    case 2:
                        MoveForward();
                        break;
                    case 3:
                        MoveRight();
                        break;
                    default:
                        print("Error in movement switch.");
                        break;
                }
            }
        }
    }

    public bool GetPull()
    {
        return triggerPull.GetState(handType);
    }

    public float GetPullAmount()
    {
        return Input.GetAxis("Move");
    }

    public void MoveForward()
    {
        vrSpace.transform.position += Vector3.forward * (moveSpeed * squeezeAmount.GetAxis(handType)) * Time.deltaTime;
        print("Moving forward");
    }

    public void MoveRight()
    {
        vrSpace.transform.position += Vector3.right * (moveSpeed * squeezeAmount.GetAxis(handType)) * Time.deltaTime;
        print("Moving right");
    }

    public void MoveBack()
    {
        vrSpace.transform.position += Vector3.back * (moveSpeed * squeezeAmount.GetAxis(handType)) * Time.deltaTime;
        print("Moving backward");
    }

    public void MoveLeft()
    {
        vrSpace.transform.position += Vector3.left * (moveSpeed * squeezeAmount.GetAxis(handType)) * Time.deltaTime;
        print("Moving left");
    }
}
