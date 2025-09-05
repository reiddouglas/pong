using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += UpdateScore;
    }

    private void OnDestroy()
    {
        ScoreManager.Instance.OnScoreChanged -= UpdateScore;
    }

    void UpdateScore(int[] score)
    {
        scoreText.text = $"{score[0]} - {score[1]}";
    }

}
