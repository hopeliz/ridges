using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{
    public Transform whatShouldFollow;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        yOffset = whatShouldFollow.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        whatShouldFollow.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        whatShouldFollow.eulerAngles = new Vector3(whatShouldFollow.eulerAngles.x, transform.eulerAngles.y, whatShouldFollow.eulerAngles.z);
        
    }
}
