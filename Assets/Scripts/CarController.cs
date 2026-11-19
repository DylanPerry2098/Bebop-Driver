using UnityEngine;

public class CarController : MonoBehaviour
{
    public InputHandler inputHandler;
    public float speed = 5f;
    public float moveSpeed = 3f;
    public float laneDistance = 2f;
    public int maxLane = 2;
    private int currentLane = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player input
        currentLane += inputHandler.GetMovement();

        currentLane = Mathf.Clamp(currentLane, 0, maxLane - 1);

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
}
