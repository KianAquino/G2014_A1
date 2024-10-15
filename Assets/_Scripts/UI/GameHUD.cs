using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        PlayerManager.Instance?.Stats.ScoreChanged.AddListener(UpdateScore);
    }

    private void OnDisable()
    {
        PlayerManager.Instance?.Stats.ScoreChanged.RemoveListener(UpdateScore);
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = $"SCORE\n\n{score}";
    }
}
