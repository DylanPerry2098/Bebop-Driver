using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Store store;
    public int testScore = 0;
    public static int score = 0;

    private TMP_Text scoreText;

    void Start()
    {
        if (testScore > 0)
        {
            score = testScore;
            UpdateScore();
        }
    }

    private void Awake()
    {
        Store.successEvent += OnSlideInputEvent;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnSlideInputEvent()
    {
        IncreaseScore();
    }
    
    public void SetScoreText(TMP_Text newText)
    {
        scoreText = newText;
        UpdateScore();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    public void DecreaseScore()
    {
        score = Mathf.Max(0, score - 1);
        Debug.Log("New Score: " + score);
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
