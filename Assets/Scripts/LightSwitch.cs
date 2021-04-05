using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public bool lightOn = false;
    public Material onMaterial;
    public Material offMaterial;
    public List<GameObject> connectedLamps;
    public List<GameObject> connectedLights;
    public GameObject physicalSwitch;
    public Vector3 switchOnRotation;
    public Vector3 switchOffRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (lightOn)
        {
            switchOnRotation = physicalSwitch.transform.eulerAngles;
            switchOffRotation = new Vector3(physicalSwitch.transform.eulerAngles.x, physicalSwitch.transform.eulerAngles.y, physicalSwitch.transform.eulerAngles.z + 30);
        }
        else
        {
            switchOffRotation = physicalSwitch.transform.eulerAngles;
            switchOnRotation = new Vector3(physicalSwitch.transform.eulerAngles.x, physicalSwitch.transform.eulerAngles.y, physicalSwitch.transform.eulerAngles.z - 30);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // When the light is on
        if (lightOn)
        {
            print("Light is on");

            physicalSwitch.transform.eulerAngles = switchOnRotation;
            
            for (int i = 0; i < connectedLights.Capacity; i++)
            {
                connectedLights[i].SetActive(true);
            }

            for (int i = 0; i < connectedLamps.Capacity; i++)
            {
                connectedLamps[i].GetComponent<Renderer>().material = onMaterial;
            }
        }
        else
        {
            print("light is off");

            physicalSwitch.transform.eulerAngles = switchOffRotation;

            for (int i = 0; i < connectedLights.Capacity; i++)
            {
                connectedLights[i].SetActive(false);
            }

            for (int i = 0; i < connectedLamps.Capacity; i++)
            {
                connectedLamps[i].GetComponent<Renderer>().material = offMaterial;
            }
        }
    }

    public void TurnLightsOn()
    {
        lightOn = true;
    }

    public void TurnLightsOff()
    {
        lightOn = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            GetComponent<AudioSource>().Play();
            lightOn = !lightOn;
        }
    }
}
