using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMenuTarget : MonoBehaviour
{
    public Transform menuTarget;
    public GameObject rightBall;

    void Update()
    {
        Debug.DrawRay(rightBall.transform.position, rightBall.transform.TransformDirection(Vector3.forward), Color.red);

        if (Physics.Raycast(rightBall.transform.position, rightBall.transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, 9))
        {
            if (!menuTarget.GetComponent<OpenCloseMenuBackground>().menuOpen)
            {
                menuTarget.position = hit.point;
            }
        }
    }
}
