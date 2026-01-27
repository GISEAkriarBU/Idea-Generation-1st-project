using TMPro;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.SetScoreText(scoreText);
        }
    }
}
