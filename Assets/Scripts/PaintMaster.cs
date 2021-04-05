using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMaster : MonoBehaviour
{
    public bool wall1painted = false;
    public bool wall2painted = false;
    public bool wall3painted = false;
    public bool wall4painted = false;

    public bool roomPainted = false;
    public int colorScore;

    public GameObject prompt;
    public GameObject incorrectResponse;
    public GameObject correctResponse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wall1painted && wall2painted && wall3painted && wall4painted)
        {
            roomPainted = true;
            prompt.SetActive(false);
        }

        if (roomPainted)
        {
            if (colorScore > 0 && colorScore < 3)
            {
                // Incorrect color
                incorrectResponse.SetActive(true);
                roomPainted = false;
                wall1painted = false;
                wall2painted = false;
                wall3painted = false;
                wall4painted = false;
            }

            if (colorScore >= 3)
            {
                incorrectResponse.SetActive(false);
                correctResponse.SetActive(true);
            }
        }
    }
}
