using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovementCollider : MonoBehaviour
{
    public PlaceMenuTarget placeMenuTarget;
    public Transform thingToFollow;
    public float offset = 0.2F;
    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, thingToFollow.position.y - offset, transform.position.z);

        if (transform.position.y + offset > placeMenuTarget.secondFloor.transform.position.y)
        {
            placeMenuTarget.floor = 1;
        } else
        {
            placeMenuTarget.floor = 0;
        }
    }
}
