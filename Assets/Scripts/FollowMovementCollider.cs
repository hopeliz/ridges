using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovementCollider : MonoBehaviour
{
    public Transform thingToFollow;
    public float offset = 0.1431707F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, thingToFollow.position.y - offset, transform.position.z);
    }
}
