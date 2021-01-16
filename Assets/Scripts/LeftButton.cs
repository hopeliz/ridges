using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    public GameObject menuTarget;
    public GameObject menuContentContainer;

    public void OnTriggerEnter(Collider other)
    {
        print("Something is touching the left button: " + other.gameObject.name);

        if (other.gameObject.tag == "Controller")
        {
            menuContentContainer.GetComponent<MenuContent>().GoBack();
        }
    }
}
