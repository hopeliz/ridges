using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float moveSpeed = 1;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }
    /**
    public void OnCollisionEnter(Collision collision)
    {
        print("I hit " + collision.transform.name);

        if (collision.transform.tag == "Stairs")
        {
            if (GetComponent<Rigidbody>() == null)
            {
                gameObject.AddComponent<Rigidbody>();
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Stairs")
        {
            if (GetComponent<Rigidbody>() == null)
            {
                gameObject.AddComponent<Rigidbody>();
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Stairs")
        {
            if (GetComponent<Rigidbody>() != null)
            {
                Destroy(GetComponent<Rigidbody>());
            }
        }
    }
    **/
}
