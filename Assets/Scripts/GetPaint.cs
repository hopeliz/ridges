using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPaint : MonoBehaviour
{
    public GameObject roller;
    public int colorScore;
    public Material paintMaterial;

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
        if (other.tag == "Paint Can")
        {
            paintMaterial = other.GetComponent<PaintInfo>().paintMaterial;
            roller.GetComponent<MeshRenderer>().material = paintMaterial;
            colorScore = other.GetComponent<PaintInfo>().colorScore;
        }
    }
}
