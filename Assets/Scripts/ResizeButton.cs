using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeButton : MonoBehaviour
{
    public GameObject resizeMenu;
    public bool grow = false;
    public bool shrink = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            if (grow)
            {
                resizeMenu.GetComponent<ResizeMenu>().Grow();
            }

            if (shrink)
            {
                resizeMenu.GetComponent<ResizeMenu>().Shrink();
            }

            if (!grow && !shrink)
            {
                resizeMenu.GetComponent<ResizeMenu>().ResetSize();
            }
        }
    }
}
