using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Until I find a way to fix this with rotation values, the door should begin at 180 or -180 euler angles.
 **/

public class DoorBehavior : MonoBehaviour
{
    [Header("Door Info")]
    public string doorName = "";
    public int doorType = 0;

    [Header("Door State")]
    public bool doorLocked = false;
    public bool doorClosed = true;
    public bool doorFullyOpen = false;
    public bool doorOpening = false;
    public bool doorClosing = false;
    public bool doorTried = false;

    [Header("Door Limits")]
    //public bool useDoorLimits = true;
    public float doorClosedRotation;
    [Tooltip("Should not be less than zero or greater than 359")]
    public float doorRotation;
    public float doorOpenRotation;
    public bool doorOpensClockwise = true;
    public float speed = 50;

    [Header("Prompts")]
    public bool showPrompts = false;
    public GameObject openPrompts;
    public GameObject closePrompts;
    public GameObject lockedPrompts;

    [Header("Audio")]
    public GameObject openSound;
    public GameObject closeSound;
    public GameObject lockedSound;

    [Header("Testing Controls")]
    [Tooltip("G for Open, H for Close")]
    public bool useKeyboardControls = false;

    // Start is called before the first frame update
    void Start()
    {
        if (doorClosed)
        {
            doorClosedRotation = transform.localEulerAngles.y;

            // If door is closed and locked, how far it can open does not matter - it can't open
            if (doorLocked)
            {
                doorOpenRotation = doorClosedRotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        doorRotation = transform.localEulerAngles.y;

        if (showPrompts)
        {
            if (doorClosed)
            {
                // Show "open" prompt
                openPrompts.SetActive(true);
                closePrompts.SetActive(false);
            }
            else
            {
                openPrompts.SetActive(false);
            }

            if (doorFullyOpen)
            {
                // Show "close" prompt
                closePrompts.SetActive(true);
                openPrompts.SetActive(false);
            }
            else
            {
                closePrompts.SetActive(false);
            }

            if (doorLocked)
            {
                // Have the player try the door first to find it locked
                if (!doorTried)
                {
                    // Show "open" prompt
                    openPrompts.SetActive(true);
                }
                else
                {
                    // Show "locked" prompt
                    lockedPrompts.SetActive(true);
                    openPrompts.SetActive(false);
                }
                
            }
            else
            {
                lockedPrompts.SetActive(false);
            }
        }
        else
        {
            openPrompts.SetActive(false);
            closePrompts.SetActive(false);
            lockedPrompts.SetActive(false);
        }

        if (doorOpening)
        {
            if (doorOpensClockwise)
            {
                if (transform.localEulerAngles.y < doorOpenRotation)
                {
                    transform.Rotate(Vector3.forward * Time.deltaTime * speed);
                }

                if (transform.localEulerAngles.y >= doorOpenRotation)
                {
                    doorOpening = false;
                    doorFullyOpen = true;
                }
            }
            else
            {
                if (transform.localEulerAngles.y > doorOpenRotation)
                {
                    transform.Rotate(Vector3.back * Time.deltaTime * speed);
                }

                if (transform.localEulerAngles.y <= doorOpenRotation)
                {
                    doorOpening = false;
                    doorFullyOpen = true;
                }
            }
        }

        if (doorClosing)
        {
            if (doorOpensClockwise)
            {
                if (transform.localEulerAngles.y > doorClosedRotation)
                {
                    transform.Rotate(Vector3.back * Time.deltaTime * speed);
                }

                if (transform.localEulerAngles.y <= doorClosedRotation)
                {
                    doorClosing = false;
                }
            }
            else
            {
                if (transform.localEulerAngles.y < doorClosedRotation)
                {
                    transform.Rotate(Vector3.forward * Time.deltaTime * speed);
                }

                if (transform.localEulerAngles.y >= doorClosedRotation)
                {
                    doorClosing = false;
                }
            }
        }

        // For testing and keyboard control
        if (useKeyboardControls)
        {
            if (Input.GetKeyDown(KeyCode.G)) { OpenDoor(); }

            if (Input.GetKeyDown(KeyCode.H)) { CloseDoor(); }
        }
    }

    public void OpenDoor()
    {
        if (!doorLocked)
        {
            if (doorOpensClockwise)
            {
                if (transform.localEulerAngles.y < doorOpenRotation)
                {
                    doorClosing = false;
                    doorOpening = true;
                    openSound.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                if (transform.localEulerAngles.y > doorOpenRotation)
                {
                    doorClosing = false;
                    doorOpening = true;
                    openSound.GetComponent<AudioSource>().Play();
                }
            }
        }

        if (doorLocked)
        {
            lockedSound.GetComponent<AudioSource>().Play();
        }

        doorTried = true;
    }

    public void CloseDoor()
    {
        if (doorOpensClockwise)
        {
            if (transform.localEulerAngles.y > doorClosedRotation)
            {
                doorOpening = false;
                doorClosing = true;
                doorFullyOpen = false;
                closeSound.GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            if (transform.localEulerAngles.y < doorClosedRotation)
            {
                doorOpening = false;
                doorClosing = true;
                doorFullyOpen = false;
                closeSound.GetComponent<AudioSource>().Play();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        print("something is colliding");

        if (other.name == "Test Controller")
        {
            print("Test contoller in the house!");
        }

        if (other.tag == "Hand")
        {
            print("My hand is touching " + doorName + " which is type " + doorType + ".");

            /* Add this if pulling the trigger is required for opening the door

            ControllerReference controllerReference = other.gameObject.GetComponentInParent<ControllerReference>();
            if (controllerReference.GetGrabDown())
            {
            */
            
                if (doorClosed)
                {
                    OpenDoor();
                }

                if (doorFullyOpen)
                {
                    CloseDoor();
                }
            //}
        }

    }
    public void OnTriggerStay(Collider other)
    {
        print("something is colliding");

        if (other.name == "Test Controller")
        {
            print("Test contoller in the house!");
             if (Input.GetKeyDown(KeyCode.Space))
            {
                if (doorClosed)
                {
                    OpenDoor();
                }

                if (doorFullyOpen)
                {
                    CloseDoor();
                }
            }
        }

        if (other.tag == "Hand")
        {
            print("My hand is touching " + doorName + " which is type " + doorType + ".");

            /* Add this if pulling the trigger is required for opening the door

            ControllerReference controllerReference = other.gameObject.GetComponentInParent<ControllerReference>();
            if (controllerReference.GetGrabDown())
            {
            */
            /*
                if (doorClosed)
                {
                    OpenDoor();
                }

                if (doorFullyOpen)
                {
                    CloseDoor();
                }
               */
            //}
        }
    }
}
