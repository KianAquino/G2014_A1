using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private float _speed;
    private SpriteRenderer _spriteRenderer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !PlayerManager.Instance.IsWearingMask) Collected();
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        SetRandomSprite();
    }

    private void FixedUpdate()
    {
        Fall();
    }

    private void Fall()
    {
        transform.position += Vector3.down * _speed * Time.fixedDeltaTime;
    }

    private void Collected()
    {
        PlayerManager.Instance.Stats.AddScore();
        AudioSystem.Instance.PlaySFX(SFXType.EAT, 0.25f);

        Destroy(gameObject);
    }

    private void SetRandomSprite()
    {
        _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
    }

    public void SetSpeed(float speed) => _speed = speed;
}
