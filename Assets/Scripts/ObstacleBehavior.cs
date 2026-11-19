using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
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
