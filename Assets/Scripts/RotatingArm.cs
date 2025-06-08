using UnityEngine;

public class RotatingArm : MonoBehaviour
{
    public float rotationSpeed = 200f; // Degrees per second

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
