using System;
using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public InputHandler inputHandler;
    public float speed = 5f;
    public float moveSpeed = 3f;
    public float laneDistance = 2f;
    public int maxLane = 2;
    private int currentLane = 1;
    private float timeElapsed;

    private bool isLerping = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // This will be changed to include the judge's input
        // Beat has to be approved by judge, event to change lane sent out
        Store.changeLaneEvent += OnChangeLaneEvent; 
        // Store.slideInputEvent += ChangeLane; // Debug
    }

    void OnChangeLaneEvent(int input)
    {
        ChangeLane(input);
    }

    // Called by Store event
    void ChangeLane(int input)
    {
        // Either this should be handled by the Judge class, or there should be a better way of changing lanes.
        if (isLerping)
        {
            return;
        }
        // Player input
        currentLane += input;
        currentLane = Mathf.Clamp(currentLane, 0, maxLane - 1);

        float targetX = (currentLane - 1) * laneDistance;
        
        Vector3 targetPosition = new Vector3(
            targetX,
            transform.position.y,
            transform.position.z
        );

        StartCoroutine(LerpCar(targetPosition));
    }

    IEnumerator LerpCar(Vector3 targetPosition)
    {
        isLerping = true;
        timeElapsed = 0;
        float lerpTime = targetPosition.magnitude / moveSpeed;
        
        while (timeElapsed < 0.25f)
        {
            timeElapsed += Time.deltaTime;
            timeElapsed = Mathf.Clamp(timeElapsed, 0, 1);
            
            float t = timeElapsed / lerpTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, t);
            
            yield return null;
        }

        transform.position = targetPosition;
        isLerping = false;
    }
}
