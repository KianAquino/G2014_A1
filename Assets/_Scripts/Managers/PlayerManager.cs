using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private Stats _stats = new Stats();

    // Read-Only
    public Stats Stats { get { return _stats; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Stats.AddScore();
    }
}

[System.Serializable]
public class Stats
{
    public float Speed;
    public float MaxHealth;
    public float CurrentHealth { get; private set; }
    public int Score;

    public UnityEvent<int> ScoreChanged;

    public Stats()
    {
        CurrentHealth = MaxHealth;
    }

    /// <summary>
    /// Adds health to the stat holder's current health.
    /// Caps the value to the max health.
    /// </summary>
    public void Heal(float health)
    {
        float newHealth = CurrentHealth + health;

        // If newHealth is greater than _maxHealth, use _maxHealth.
        // If not, use newHealth.
        CurrentHealth = newHealth > MaxHealth ? MaxHealth : newHealth;
    }

    /// <summary>
    /// Reduces health to the stat holder's current health.
    /// </summary>
    /// <returns>True if the stat holder no longer has health or is dead.</returns>
    public bool TakeDamage(float damage)
    {
        float newHealth = CurrentHealth - damage;

        CurrentHealth = newHealth < 0f ? 0f : newHealth;

        return CurrentHealth == 0f;
    }

    public void AddScore(int score = 1)
    {
        Score += score;

        ScoreChanged?.Invoke(Score);
    }
}