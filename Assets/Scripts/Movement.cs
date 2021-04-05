using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public ControllerReference controller;
    public GameObject player;
    //public GameObject playerSafetySphere;
    public float moveSpeed = 4;
    public float rotateSpeed = 50;
    public float force = 50;
    public bool useForce = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (controller.leftHand)
        {
            if (controller.GetForward())
            {
                GoForward();
            }

            if (controller.GetBack())
            {
                GoBack();
            }

            if (controller.GetLeft())
            {
                GoLeft();
            }

            if (controller.GetRight())
            {
                GoRight();
            }
        }
        */

        if (!controller.leftHand)
        {
            if (controller.GetLeft())
            {
                RotateLeft();
            }

            if (controller.GetRight())
            {
                RotateRight();
            }
        }
    }

    public void GoForward()
    {
        
        print("Move Forward");

        if (useForce)
        {
            // Using AddForce()
            //playerSafetySphere.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        }
        else
        {
            // Using Translate
            player.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            //player.transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        }
    }

    public void GoBack()
    {
        print("Move Back");

        if (useForce)
        {
            // Using AddForce()
            //playerSafetySphere.GetComponent<Rigidbody>().AddForce(Vector3.back * force);
        }
        else
        {
            // Using Translate
            player.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            //player.transform.position += Vector3.back * moveSpeed * Time.deltaTime;

        }
    }

    public void GoLeft()
    {
        print("Move Left");

        if (useForce)
        {
            // Using AddForce()
            //playerSafetySphere.GetComponent<Rigidbody>().AddForce(Vector3.left * force);
        }
        else
        {
            // Using Translate
            player.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            //player.transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        }
    }

    public void GoRight()
    {
        print("Move Right");

        if (useForce)
        {
            // Using AddForce()
            //playerSafetySphere.GetComponent<Rigidbody>().AddForce(Vector3.right * force);
        }
        else
        {
            // Using Translate
            player.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //player.transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        }
    }

    public void RotateLeft()
    {
        // Using Rotate
        player.transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        print("Rotate Left");
    }

    public void RotateRight()
    {
        // Using Rotate
        player.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        print("Rotate Right");
    }
}
