using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsHelp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Stairs")
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Stairs")
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Stairs")
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
