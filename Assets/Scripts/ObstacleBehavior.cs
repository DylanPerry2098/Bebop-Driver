using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;
    public float travelDistance = 50f;

    private float distanceTravelled;

    void Update()
    {
        float movement = speed * Time.deltaTime;

        transform.Translate(
            Vector3.back * movement,
            Space.World
        );

        distanceTravelled += movement;

        if (distanceTravelled >= travelDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Obstacle collided with: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit an obstacle!");
            Debug.Log(ScoreManager.instance);
            ScoreManager.instance.DecreaseScore();
        }
    }
}
