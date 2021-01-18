using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuContent : MonoBehaviour
{
    [Header("Pages")]
    public List<GameObject> menuContentScreens;
    public int page = 0;

    [Header("Buttons")]
    public GameObject leftButton;
    public GameObject rightButton;

    void Update()
    {
        // Turn on current page
        menuContentScreens[page].SetActive(true);

        // If multiple pages
        if (menuContentScreens.Capacity > 1)
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);

            // If first page
            if (page == 0)
            {
                leftButton.SetActive(false);
            }

            // If last page
            if (page == menuContentScreens.Capacity - 1)
            {
                rightButton.SetActive(false);
            }
        }
    }

    public void GoForward()
    {
        if (page < menuContentScreens.Capacity)
        {
            menuContentScreens[page].SetActive(false);
            menuContentScreens[page + 1].SetActive(true);
            page++;
        }
    }

    public void GoBack()
    {
        if (page > 0)
        {
            menuContentScreens[page].SetActive(false);
            menuContentScreens[page - 1].SetActive(true);
            page--;
        }
    }
}
