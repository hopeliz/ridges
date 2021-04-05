using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControl : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerPos;
    public bool playerIsOutside = true;
    public bool playerInStairway = false;
    public int currentFloor = 0;   // 0 is ground/outside

    [Header("Floor Thresholds")]
    public Transform floor1TeleportArea;
    public float floor1YThreshold;
    public Transform floor2TeleportArea;
    public float floor2YThreshold;
    public Transform floor3TeleportArea;
    public float floor3YThreshold;
    public Transform floor4TeleportArea;
    public float floor4YThreshold;

    [Header("Building Thresholds")]
    public Transform northWall;
    public float buildingNorthThreshold;
    public float buildingEastThreshold;
    public Transform southWall;
    public float buildingSouthThreshold;
    public Transform westWall;
    public float buildingWestThreshold;

    [Header("Full floors")]
    public GameObject floor0;
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;

    [Header("Interior")]
    public GameObject floor1interior;
    public GameObject floor2interior;
    public GameObject floor3interior;
    public GameObject dropOffWall;

    [Header("Stairway Doors")]
    public DoorBehavior floor1door;
    public DoorBehavior floor2door;
    public DoorBehavior floor3door;
    

    // Start is called before the first frame update
    void Start()
    {
        floor1YThreshold = floor1TeleportArea.position.y;
        floor2YThreshold = floor2TeleportArea.position.y;
        floor3YThreshold = floor3TeleportArea.position.y;
        floor4YThreshold = floor4TeleportArea.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        // If farther into the building and not on the ground
        if (playerPos.y >= floor1YThreshold &&
            playerPos.z > buildingNorthThreshold)
        {
            playerIsOutside = false;
        }

        // If outside of building on the ground
        if (playerPos.y < floor1YThreshold) {

            currentFloor = 0;

            if (playerPos.z < buildingNorthThreshold &&
                playerPos.z > buildingSouthThreshold &&
                playerPos.x < buildingEastThreshold &&
                playerPos.x > buildingWestThreshold)
            {
                playerIsOutside = true;
            }
        }

        // If player is in walls of stairway
        if (playerInStairway) { 

            // if the player is in the stairway, they aren't outside
            playerIsOutside = false;
        }

        // If player is on Floor 1
        if (playerPos.y >= floor1YThreshold && 
            playerPos.y < floor2YThreshold)
        {
            // player is on Floor 1
            currentFloor = 1;
        }

        // If player is on Floor 2
        if (playerPos.y >= floor2YThreshold &&
            playerPos.y < floor3YThreshold)
        {
            currentFloor = 2;
        }

        // If player is on Floor 3
        if (playerPos.y >= floor3YThreshold &&
            playerPos.y < floor4YThreshold)
        {
            currentFloor = 3;
        }

        // If player is on Floor 4
        if (playerPos.y >= floor4YThreshold)
        {
            currentFloor = 4;
        }
        

        // if inside and on Floor 1
        if (currentFloor == 1 && !playerIsOutside)
        {
            // Remove dropoff wall
            dropOffWall.SetActive(false);

            // Activate Floor 1
            floor1.SetActive(true);
            floor1interior.SetActive(true);

            // Hide Basement
            floor0.SetActive(false);

            // Hide Floor Interior Above
            floor2interior.SetActive(false);

            // Hide floors above that
            floor3.SetActive(false);
            floor4.SetActive(false);
        }

        // if on Floor 2
        if (currentFloor == 2)
        {
            // Remove dropoff wall
            dropOffWall.SetActive(false);

            // Activate Floor 2
            floor2.SetActive(true);
            floor2interior.SetActive(true);

            // Hide Basement & Floor 1
            floor0.SetActive(false);

            if (!playerInStairway)
            {
                floor1.SetActive(false);
            }
            else
            {
                floor1.SetActive(true);
            }

            // Hide Floor Interior Above
            floor3interior.SetActive(false);

            // Hide floors above that
            floor4.SetActive(false);
        }

        // if on Floor 3
        if (currentFloor == 3)
        {
            // Remove dropoff wall
            dropOffWall.SetActive(false);

            // Activate Floor 3
            floor3.SetActive(true);
            floor3interior.SetActive(true);

            // Hide Basement & Floor 1 & Floor 2
            floor0.SetActive(false);
            floor1.SetActive(false);

            if (!playerInStairway)
            {
                floor2.SetActive(false);
            }
            else
            {
                floor2.SetActive(true);
            }
        }

        // if door is open while in stairway
        if (playerInStairway)
        {
            if (!floor1door.doorClosed)
            {
                floor1interior.SetActive(true);
            }

            if (!floor2door.doorClosed)
            {
                floor2interior.SetActive(true);
            }

            if (!floor3door.doorClosed)
            {
                floor3interior.SetActive(true);
            }
        }

        // If outside
        if (playerIsOutside || currentFloor == 0 || playerInStairway)
        {
            // Activate all floors
            floor0.SetActive(true);
            floor1.SetActive(true);
            floor2.SetActive(true);
            floor3.SetActive(true);
            floor4.SetActive(true);

            if (!playerInStairway)
            {
                // Remove interior
                floor1interior.SetActive(false);
                floor2interior.SetActive(false);
                floor3interior.SetActive(false);
            }

            // Put up drop off wall
            dropOffWall.SetActive(true);
        }
    }
}
