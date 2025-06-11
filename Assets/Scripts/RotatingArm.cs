using UnityEngine;
/*
* Author: Xander 
* Date: 8/6/25
* Description: This script handles the functionality of the spinning fan in the 3rd level.
*/
public class RotatingArm : MonoBehaviour
{
    public float rotationSpeed = 200f; // Rotation spd in degrees per second

    void Update()
    // Rotates the object around the Y axis (Vector3.up) at the specified speed, which can be changed in inspector
    // Time.deltaTime ensures the rotation is frame rate independent
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
