using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject menuTarget;

    public void ButtonFunction()
    {
        menuTarget.GetComponent<OpenCloseMenuBackground>().CloseMenu();
    }

    public void OnTriggerEnter(Collider other)
    {
        print("Something is touching the close button: " + other.gameObject.name);

        if (other.gameObject.tag == "Controller")
        {
            ButtonFunction();
        }
    }
}
