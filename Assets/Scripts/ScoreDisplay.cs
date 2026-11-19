using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private void Start()
    {
        ScoreManager.instance.SetScoreText(GetComponent<TMP_Text>());
    }
}
