using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private Stats _stats = new Stats();
    private bool _canMove = true;

    public bool CanMove => _canMove;
    public bool IsWearingMask => !_canMove;

    // Read-Only
    public Stats Stats { get { return _stats; } }

    public void ResetStats()
    {
        Stats.CurrentHealth = Stats.MaxHealth;
        Stats.Score = 0;
    }

    public void SetCanMove(bool canMove) => _canMove = canMove;
}

[System.Serializable]
public class Stats
{
    public int Speed;
    public int MaxHealth;
    public int CurrentHealth;
    public int Score;

    [HideInInspector] public UnityEvent<int> OnScoreChanged;
    [HideInInspector] public UnityEvent<float> OnHealthChanged;

    /// <summary>
    /// Adds health to the stat holder's current health.
    /// Caps the value to the max health.
    /// </summary>
    public void Heal(int health = 1)
    {
        int newHealth = CurrentHealth + health;

        // If newHealth is greater than _maxHealth, use _maxHealth.
        // If not, use newHealth.
        CurrentHealth = newHealth > MaxHealth ? MaxHealth : newHealth;

        OnHealthChanged?.Invoke(CurrentHealth);
    }

    /// <summary>
    /// Reduces health to the stat holder's current health.
    /// </summary>
    /// <returns>True if the stat holder no longer has health or is dead.</returns>
    public bool TakeDamage(int damage = 1)
    {
        int newHealth = CurrentHealth - damage;

        CurrentHealth = newHealth < 0 ? 0 : newHealth;

        OnHealthChanged?.Invoke(CurrentHealth);

        return CurrentHealth == 0f;
    }

    public void AddScore(int score = 1)
    {
        Score += score;

        OnScoreChanged?.Invoke(Score);
    }
}