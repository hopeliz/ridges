using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBigFloorplan : MonoBehaviour
{
    public GameObject bigFloorplan;

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
            bigFloorplan.SetActive(true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            bigFloorplan.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            bigFloorplan.SetActive(false);
        }
    }
}
