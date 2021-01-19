using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMenuTarget : MonoBehaviour
{
    public Transform menuTarget;
    public GameObject rightBall;
    public GameObject groundFloor;
    public GameObject secondFloor;
    public int floor = 0;

    void Update()
    {
        Debug.DrawRay(rightBall.transform.position, rightBall.transform.TransformDirection(Vector3.forward), Color.red);

        if (Physics.Raycast(rightBall.transform.position, rightBall.transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, 9))
        {
            if (!menuTarget.GetComponent<OpenCloseMenuBackground>().menuOpen)
            {
                if (floor == 0)
                {
                    if (hit.point.y >= groundFloor.transform.position.y && hit.point.y < secondFloor.transform.position.y)
                    {
                        menuTarget.position = hit.point;
                    }
                }

                if (floor == 1)
                {
                    if (hit.point.y >= secondFloor.transform.position.y)
                    {
                        menuTarget.position = new Vector3(hit.point.x, secondFloor.transform.position.y, hit.point.z);
                    }
                }
            }
        }
    }
}
