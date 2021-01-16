using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeMenu : MonoBehaviour
{
    public GameObject menuTarget;
    public GameObject menuConentContainer;
    public GameObject parentWhenGrowing;
    public Vector3 originalScale;
    
    void Start()
    {
        originalScale = transform.lossyScale;
    }

    public void Grow()
    {
        menuTarget.transform.localScale = new Vector3(menuTarget.transform.localScale.x * 1.25F, menuTarget.transform.localScale.y * 1.25F, menuTarget.transform.localScale.z * 1.25F);
    }

    public void Shrink()
    {
        menuTarget.transform.localScale = new Vector3(menuTarget.transform.localScale.x / 1.25F, menuTarget.transform.localScale.y / 1.25F, menuTarget.transform.localScale.z / 1.25F);
    }

    public void ResetSize()
    {
        menuTarget.transform.localScale = new Vector3(1, 1, 1);
    }
}
