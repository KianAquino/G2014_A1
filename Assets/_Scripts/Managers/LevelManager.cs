using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private float _gravity;
    [SerializeField] private float _baseSpawnInterval;
    [Header("Spawn Area")]
    [SerializeField] private Vector2 _from;
    [SerializeField] private Vector2 _to;
    [SerializeField] private GameObject _fallingObject;

    public GameObject FallingObject => _fallingObject;
    public float BaseSpawnInterval => _baseSpawnInterval;

    public bool DrawGizmos = false;

    public float Gravity => _gravity;

    private void Start()
    {
        PlayerManager.Instance.ResetStats();

        FallingObjectsSpawner.Instance.Begin();
        SpringBonnieSpawner.Instance.Begin();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Missed Falling Object
        if (collision.CompareTag("FallingObject"))
        {
            bool isDead = PlayerManager.Instance.Stats.TakeDamage();
            AudioSystem.Instance.PlaySFX(SFXType.HURT);

            if (isDead) GameManager.Instance.GameOver();
        }

        // Despawn Spring Bonnie
        if (collision.CompareTag("SpringBonnie")) AudioSystem.Instance.PlaySFX(SFXType.BONNIE_EXIT);

        Destroy(collision.gameObject);
    }

    public Vector2 GetRandomSpawnPosition()
    {
        float x = Random.Range(_from.x, _to.x);
        float y = Random.Range(_from.y, _to.y);

        return new Vector2(x, y);
    }

    private void OnDrawGizmos()
    {
        if (!DrawGizmos) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_from, _to);
    }
}
