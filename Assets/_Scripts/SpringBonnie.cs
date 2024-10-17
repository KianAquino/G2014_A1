using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBonnie : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody2D;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!PlayerManager.Instance.IsWearingMask)
            {
                AudioSystem.Instance.PlaySFX(SFXType.HURT);
                GameManager.Instance.GameOver();
            }
        }
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        AudioSystem.Instance.PlaySFX(SFXType.BONNIE_ENTER, 0.5f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = Vector2.left * _speed;
    }
}
