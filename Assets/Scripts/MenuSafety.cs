using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSafety : MonoBehaviour
{
    public GameObject menuTarget;
    public GameObject menuTargetContainer;
    public bool safeMenu = true;
    public Material transparent;

    public void OnTriggerEnter(Collider other)
    {
        // If the menu isn't open and the object entering isn't a controller
        // It is not safe for the menu to appear

        if (!menuTarget.GetComponent<OpenCloseMenuBackground>().menuOpen && other.gameObject.tag != "Controller")
        {
            print("Menu is touching " + other.gameObject.name);
            safeMenu = false;
            menuTargetContainer.SetActive(false);
            menuTarget.GetComponent<Renderer>().material = transparent;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        // If the menu isn't open and the object and the colliding object isn't a controller
        // It is not safe for the menu to appear

        if (!menuTarget.GetComponent<OpenCloseMenuBackground>().menuOpen && other.gameObject.tag != "Controller")
        {
            print("Menu is touching " + other.gameObject.name);
            safeMenu = false;
            menuTargetContainer.SetActive(false);
            menuTarget.GetComponent<Renderer>().material = transparent;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        // if the menu isn't open and the area is no longer coliding with an object
        // It is safe for the menu

        if (!menuTarget.GetComponent<OpenCloseMenuBackground>().menuOpen)
        {
            safeMenu = true;
            menuTargetContainer.SetActive(false);
            menuTarget.GetComponent<Renderer>().material = menuTarget.GetComponent<OpenCloseMenuBackground>().menuTargetMaterial;
        }
    }
}
