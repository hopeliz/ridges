using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour
{
    public GameObject menuTarget;
    public GameObject menuContentContainer;

    public void OnTriggerEnter(Collider other)
    {
        print("Something is touching the right button: " + other.gameObject.name);

        if (other.gameObject.tag == "Controller")
        {
            menuContentContainer.GetComponent<MenuContent>().GoForward();
        }
    }
}
