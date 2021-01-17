using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHeight : MonoBehaviour
{
    public Transform groundPlane;
    public Transform menuContents;
    public float rotateSpeed = 1;
    public float menuHeight = 0.05F;

    void Update()
    {
        // Keeps target on ground
        transform.position = new Vector3(transform.position.x, groundPlane.position.y + 0.001F, transform.position.z);

        // Control menu height
        menuContents.transform.position = new Vector3(menuContents.transform.position.x, groundPlane.position.y + 0.5F, menuContents.transform.position.z);

        // Rotates target with right mouse button
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotateSpeed);
        }
    }
}
