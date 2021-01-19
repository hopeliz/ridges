using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMoveSpeed : MonoBehaviour
{
    public MoveBox moveBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            moveBox.moveSpeed = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            moveBox.moveSpeed = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            moveBox.moveSpeed = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            moveBox.moveSpeed = 4;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            moveBox.moveSpeed = 5;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            moveBox.moveSpeed = 6;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            moveBox.moveSpeed = 7;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            moveBox.moveSpeed = 8;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            moveBox.moveSpeed = 9;
        }
    }
}
