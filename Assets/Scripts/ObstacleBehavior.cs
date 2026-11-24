using System;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public Store store;
    [Header("Movement")]
    public float speed = 10f;
    public float travelDistance = 50f;

    private float distanceTravelled;

    private void Awake()
    {
        Store.pauseGame += OnPauseGame;
        Store.resumeGame += OnResumeGame;
    }

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

    private void OnPauseGame()
    {
        Time.timeScale = 0;
    }

    private void OnResumeGame()
    {
        Time.timeScale = 1;
    }
}
