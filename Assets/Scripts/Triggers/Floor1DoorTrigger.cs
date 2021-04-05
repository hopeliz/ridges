using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor1DoorTrigger : MonoBehaviour
{
    public FloorControl floorControl;
    public GameObject triggerToShow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!floorControl.playerInStairway)
        {
            triggerToShow.SetActive(false);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            triggerToShow.SetActive(true);
        }
    }
}
