using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _Instance;
    public static ScoreManager Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = new GameObject().AddComponent<ScoreManager>();
            }
            return _Instance;
        }
    }
    public int[] scores = new int[2];
    public event Action<int[]> OnScoreChanged;

    public void AddPoint(int player)
    {
        scores[player]++;
        Debug.Log($"Player {player + 1} scored");
        OnScoreChanged?.Invoke(scores);
    }

    public void ResetScores()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = 0;
        }
        Debug.Log($"Scores reset");
        OnScoreChanged?.Invoke(scores);
    }

}
