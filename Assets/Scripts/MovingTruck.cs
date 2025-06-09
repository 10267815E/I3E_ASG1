using UnityEngine;

public class MovingTruck : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    private Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        // Move truck toward the target point
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Switch target if reached
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (target == pointB.position)
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
