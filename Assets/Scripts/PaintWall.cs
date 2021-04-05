using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWall : MonoBehaviour
{

    public PaintMaster paintMaster;
    public GameObject[] wallPanels;
    public int colorScore = 0;
    public int wallNumber;

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
        if (other.tag == "Paint Roller" && other.name == "Roller")
        {
            paintMaster.colorScore = other.GetComponent<GetPaint>().colorScore;

            for (int i = 0; i < wallPanels.Length; i++)
            {
                wallPanels[i].GetComponent<MeshRenderer>().material = other.GetComponent<GetPaint>().paintMaterial;
            }

            switch (wallNumber)
            {
                case 0:
                    paintMaster.wall1painted = true;
                    break;
                case 1:
                    paintMaster.wall2painted = true;
                    break;
                case 2:
                    paintMaster.wall3painted = true;
                    break;
                case 4:
                    paintMaster.wall4painted = true;
                    break;
                default:
                    print("Error in paint switch");
                    break;
            }
        }
    }
}
