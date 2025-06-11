using UnityEngine;

/*
* Author: Xander 
* Date: 9/6/25
* Description: This script handles the back and forth movement of the truck hazards in game
*/
public class MovingTruck : MonoBehaviour
{
    // The start and end points between which the truck will move
    public Transform pointA; // Point A for the truck to move towards/start at
    public Transform pointB; // Point B for the truck to move towards
    public float speed = 5f; // Base speed of the truck 

    private Vector3 target; // Vector3 variable to hold the target position for the truck

    void Start()
    {
        target = pointB.position; // Start moving towards Point B
    }

    void Update()
    {
        // Move truck toward the target point
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Switch target if reached (if target is Point B and truck reaches it, switch to Point A, and vice versa)
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (target == pointB.position)  // If currently at Point B, switch to Point A
            {
                target = pointA.position;
            }
            else
            {
                target = pointB.position;
            }
        }
    }
}
