using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenuLight : MonoBehaviour
{
    public Transform wholeScreenObject;
    public float rotationYOffset;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, wholeScreenObject.eulerAngles.y + rotationYOffset, transform.eulerAngles.z);
    }
}
