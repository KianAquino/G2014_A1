using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private Stats _stats;

    // Read-Only
    public Stats Stats { get { return _stats; } }

    private void Start()
    {
        
    }
}

[System.Serializable]
public class Stats
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public float Damage { get { return _damage; } }
    public float Speed { get { return _speed; } }
    public float MaxHealth { get { return _maxHealth; } }

    public Stats()
    {
        _currentHealth = _maxHealth;
    }

    /// <summary>
    /// Adds health to the stat holder's current health.
    /// Caps the value to the max health.
    /// </summary>
    public void Heal(float health)
    {
        float newHealth = _currentHealth + health;

        // If newHealth is greater than _maxHealth, use _maxHealth.
        // If not, use newHealth.
        _currentHealth = newHealth > _maxHealth ? _maxHealth : newHealth;
    }

    /// <summary>
    /// Reduces health to the stat holder's current health.
    /// </summary>
    /// <returns>True if the stat holder no longer has health or is dead.</returns>
    public bool TakeDamage(float damage)
    {
        float newHealth = _currentHealth - damage;

        _currentHealth = newHealth < 0f ? 0f : newHealth;

        return _currentHealth == 0f;
    }
}