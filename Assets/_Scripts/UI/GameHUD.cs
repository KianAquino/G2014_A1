using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _healthText;

    private void OnEnable()
    {
        PlayerManager.Instance?.Stats.OnScoreChanged.AddListener(UpdateScore);
        PlayerManager.Instance?.Stats.OnHealthChanged.AddListener(UpdateHealth);
    }

    private void OnDisable()
    {
        PlayerManager.Instance?.Stats.OnScoreChanged.RemoveListener(UpdateScore);
        PlayerManager.Instance?.Stats.OnHealthChanged.RemoveListener(UpdateHealth);
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = $"SCORE\n{score}";
    }

    private void UpdateHealth(int health)
    {
        _healthText.text = $"HEALTH\n{health}";
    }
}
