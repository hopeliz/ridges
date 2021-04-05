using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStairs : MonoBehaviour
{
    public GameObject thingToAppear;
    public GameObject thingToDisappear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            thingToAppear.SetActive(true);
            thingToDisappear.SetActive(false);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            thingToAppear.SetActive(true);
            thingToDisappear.SetActive(false);
        }
    }
}
