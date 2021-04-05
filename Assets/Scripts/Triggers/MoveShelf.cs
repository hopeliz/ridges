using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShelf : MonoBehaviour
{
    public Vector3 finalLocation;
    public bool isMoving;
    public float movespeed = 2;

    public GameObject prompt;
    public GameObject response;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position += Vector3.right * Time.deltaTime * movespeed;

            if (transform.position.x >= finalLocation.x)
            {
                isMoving = false;
                prompt.SetActive(false);
                prompt.SetActive(response);
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            if (transform.position.x >= finalLocation.x)
            {
                isMoving = true;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}

