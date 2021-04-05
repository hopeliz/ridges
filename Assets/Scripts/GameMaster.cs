using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is to help control everything.
 **/

public class GameMaster : MonoBehaviour
{
    [Header("Player Controls")]
    public GameObject player;

    [Header("Additions")]
    public GameObject outDoorThingsToDisappear;
    public GameObject outDoorThingsToAppear;

    [Header("Fact Panel Control")]
    public int empathyLevel = 0;
    public int empathyScore = 0;
    // When empathyScore reaches a threshhold, the panels will choose a different array of panels
    // public FactPanelControl factPanelControl;
    // Fact Panel Arrays will be available in factPanelControl script
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (empathyScore > 5)
        {
            empathyLevel = 1;
        }
    }
}
