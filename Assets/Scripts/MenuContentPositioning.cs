using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuContentPositioning : MonoBehaviour
{
    public Transform menuBackground;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, menuBackground.position.z - 0.001F);
    }
}
