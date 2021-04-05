using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactTriggers : MonoBehaviour
{
    [Header("Script References")]
    public GameMaster gameMaster;

    [Header("Fact Objects")]
    public GameObject factHolder;
    public GameObject[] facts;
    public GameObject factToShow;
    public bool showOnce = false;
    public int timesShown = 0;

    [Header("Fading")]
    public bool fadesIn = false;
    public bool fadesOut = true;
    public bool timed = false;
    public float fadeSpeed = 2;
    public float fadeCountdown;
    public float timeShown = 60;
    public float shownCountdown;
    public bool fadingOut = false;
    public bool fadingIn = false;
    public bool showing = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set Fade Timer
        fadeCountdown = fadeSpeed;

        // Set time shown counter
        shownCountdown = timeShown;

        if (facts.Length > 1)
        {
            if (gameMaster.empathyLevel > 0)
            {
                factToShow = facts[1];
            }
            else
            {
                factToShow = facts[0];
            }
        }
        else
        {
            factToShow = facts[0];
        }

        // Turn off facts
        for (int i = 0; i < facts.Length; i++)
        {
            facts[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only show current fact
        factToShow.SetActive(true);

        if (!fadesIn)
        {
            factToShow.GetComponent<Renderer>().material.color = new Color(factToShow.GetComponent<Renderer>().material.color.r, factToShow.GetComponent<Renderer>().material.color.g, factToShow.GetComponent<Renderer>().material.color.b, 1);
        }

        if (showOnce && timesShown > 0)
        {
            // Turn off immediately
            factToShow.SetActive(false);
        }

        if (timed)
        {
            if (showing)
            {
                shownCountdown -= Time.deltaTime;

                if (shownCountdown <= 0)
                {
                    if (fadesOut)
                    {
                        FadeOut();
                    }

                    showing = false;
                }
            }
        }

        if (fadingIn)
        {
            fadeCountdown -= Time.deltaTime;

            factToShow.GetComponent<Renderer>().material.color = new Color(factToShow.GetComponent<Renderer>().material.color.r, factToShow.GetComponent<Renderer>().material.color.g, factToShow.GetComponent<Renderer>().material.color.b, factToShow.GetComponent<Renderer>().material.color.a * (1 - (fadeCountdown / fadeSpeed)));

            if (fadeCountdown <= 0)
            {
                fadingIn = false;
                showing = true;
            }
        }

        if (fadingOut)
        {
            fadeCountdown -= Time.deltaTime;

            factToShow.GetComponent<Renderer>().material.color = new Color(factToShow.GetComponent<Renderer>().material.color.r, factToShow.GetComponent<Renderer>().material.color.g, factToShow.GetComponent<Renderer>().material.color.b, factToShow.GetComponent<Renderer>().material.color.a * (fadeCountdown / fadeSpeed));

            if (fadeCountdown <= 0)
            {
                
                fadingOut = false;
                showing = false;
            }
        }
    }

    public void FadeIn()
    {
        fadingIn = true;
        fadeCountdown = fadeSpeed;
        factToShow.GetComponent<Renderer>().material.color = new Color(factToShow.GetComponent<Renderer>().material.color.r, factToShow.GetComponent<Renderer>().material.color.g, factToShow.GetComponent<Renderer>().material.color.b, 0);
    }

    public void FadeOut()
    {
        fadingOut = true;
        fadeCountdown = fadeSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        print(other.name + "has entered.");

        if (other.tag == "Player")
        {
            factHolder.SetActive(true);

            if (fadesIn)
            {
                FadeIn();
            }

            shownCountdown = timeShown;
            fadeCountdown = fadeSpeed;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        print(other.name + "is here.");

        if (other.tag == "Player")
        {
            factHolder.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (fadesOut)
            {
                FadeOut();
                timesShown++;

                if (timesShown == 1)
                {
                    gameMaster.empathyScore++;
                }
            }

            factHolder.SetActive(false);
        }
    }
}
