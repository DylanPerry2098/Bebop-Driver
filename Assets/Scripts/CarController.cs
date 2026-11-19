using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 5f;
    public float moveSpeed = 3f;
    public float laneDistance = 2f;
    private int currentLane = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Store.updateSlidePosition += ChangeLane;
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = (currentLane - 1) * laneDistance;

        Vector3 targetPosition = new Vector3(
            targetX,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    void ChangeLane(int input)
    {
        // Player input
        currentLane += input;
        currentLane = Mathf.Clamp(currentLane, 0, 2);
    }
}
