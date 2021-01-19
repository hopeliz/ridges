using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopProgram : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}

