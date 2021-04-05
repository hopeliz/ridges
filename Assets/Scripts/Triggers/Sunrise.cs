using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunrise : MonoBehaviour
{
    public Light sun;
    public float speed = 0.25F;
    public bool isRising = false;
    public float nightLength = 30;
    public float countdownToSunrise;
    public bool isNight = true;
    public Camera vrCamera;
    public GameObject introQuads;
    public GameObject firstTrigger;

    // Start is called before the first frame update
    void Start()
    {
        countdownToSunrise = nightLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNight)
        {
            countdownToSunrise -= Time.deltaTime;

            if (countdownToSunrise <= 0)
            {
                isNight = false;
                RaiseTheSun();
            }
        }

        if (isRising)
        {
            sun.intensity += speed * Time.deltaTime;

            if (sun.intensity >= 1)
            {
                isRising = false;
                vrCamera.clearFlags = CameraClearFlags.Skybox;
                introQuads.SetActive(false);
                firstTrigger.SetActive(true);
            }
        }
    }

    public void RaiseTheSun()
    {
        isRising = true;
    }
}
