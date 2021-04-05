using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 50;
    public float jumpHeight = 200;

    void Update()
    {
        // Translate / Move
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        // Rotate
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        // For jump to work, be sure to add a Rigidbody component to your player object
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
        }
    }
}
