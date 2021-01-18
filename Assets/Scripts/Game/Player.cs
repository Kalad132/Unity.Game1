using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _rightForce;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    private Rigidbody2D _body;
    private CircleCollider2D _collider;
    private PlayerInput _input;
    private int _score;

    public UnityAction<int> ScoreChanged;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
        _input = GetComponent<PlayerInput>();
        _score = 0;
        ScoreChanged?.Invoke(_score);

    }

    private void OnEnable()
    {
        _input.Jump += Jump;
    }

    private void OnDisable()
    {
        _input.Jump -= Jump;
    }

    private void Update()
    {
        if (_body.velocity.magnitude <= _maxVelocity)
            _body.AddForce(new Vector2 (_rightForce,0) * _maxVelocity / (_body.velocity.magnitude + 1) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            AddScore();
            Destroy(coin.gameObject);
        }
    }


    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(_collider.bounds.center, _collider.radius, Vector2.down, 0.1f, _groundLayer);
        return hit.collider != null;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            _body.AddForce(new Vector2(0, _jumpForce));
        }
    }

    private void AddScore()
    {
        _score += 1;
        ScoreChanged?.Invoke(_score);
    }
}


