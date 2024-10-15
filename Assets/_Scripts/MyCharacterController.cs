using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class MyCharacterController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction; // Direction of movement
    private Vector2 _velocity;// Direction * Speed

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0f;

        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void Update()
    {
        MoveCharacter();
        UpdateAnimator();
    }

    private void MoveCharacter()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float speed = PlayerManager.Instance.Stats.Speed;

        _direction = Vector2.right * hInput;
        _velocity = _direction * speed;
        _rigidbody2D.velocity = _velocity;
    }

    private void UpdateAnimator()
    {
        _animator.Play(_direction == Vector2.zero ? "Child_Idle" : "Child_Walk");

        transform.localScale = _direction == Vector2.left ? new Vector3(-0.5f, 0.5f, 0.5f) : new Vector3(0.5f, 0.5f, 0.5f);
    }
}
