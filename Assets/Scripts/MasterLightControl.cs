using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Use light switches as the lights and turn on and off through the switch.
 **/

public class MasterLightControl : MonoBehaviour
{
    [Header("Floor 1")]
    public List<GameObject> floor1RoomLights;
    public GameObject floor1HallwayLights;
    public List<bool> floor1LightsOn;

    [Header("Floor 2")]
    public List<GameObject> floor2RoomLights;
    public GameObject floor2HallwayLights;
    public List<bool> floor2LightsOn;

    [Header("Floor 3")]
    public List<GameObject> floor3RoomLights;
    public GameObject floor3HallwayLights;
    public List<bool> floor3LightsOn;

    [Header("Floor 4)")]
    public List<GameObject> floor4RoomLights;
    public List<bool> floor4LightsOn;

    // Start is called before the first frame update
    void Start()
    {
        // -- Floor 1 --
        for (int i = 0; i < floor1RoomLights.Capacity; i++)
        {
            floor1LightsOn.Add(floor1RoomLights[i].GetComponent<LightSwitch>().lightOn);
        }

        // Hallway light switch at the end
        floor1LightsOn.Add(floor1HallwayLights.GetComponent<LightSwitch>().lightOn);

        // -- Floor 2 --
        for (int i = 0; i < floor2RoomLights.Capacity; i++)
        {
            floor2LightsOn.Add(floor2RoomLights[i].GetComponent<LightSwitch>().lightOn);
        }

        // Hallway light switch at the end
        floor2LightsOn.Add(floor2HallwayLights.GetComponent<LightSwitch>().lightOn);

        // -- Floor 3 --
        for (int i = 0; i < floor3RoomLights.Capacity; i++)
        {
            floor3LightsOn.Add(floor3RoomLights[i].GetComponent<LightSwitch>().lightOn);
        }

        // Hallway light switch at the end
        floor3LightsOn.Add(floor3HallwayLights.GetComponent<LightSwitch>().lightOn);

        // -- Floor 4 --
        for (int i = 0; i < floor4RoomLights.Capacity; i++)
        {
            floor4LightsOn.Add(floor4RoomLights[i].GetComponent<LightSwitch>().lightOn);
        }

        // Hallway light switch at the end
        floor4LightsOn.Add(floor3HallwayLights.GetComponent<LightSwitch>().lightOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
