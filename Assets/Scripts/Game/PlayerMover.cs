using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _rightForce;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _body;
    private CircleCollider2D _collider;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        AddRightForce(_rightForce);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(_collider.bounds.center, _collider.radius, Vector2.down, 0.1f, _groundLayer);
        return hit.collider != null;
    }

    public void TryJump()
    {
        if (IsGrounded())
        {
            _body.AddForce(new Vector2(0, _jumpForce));
        }
    }

    private void AddRightForce(float force)
    {
        _body.AddForce(new Vector2(force, 0) * Time.deltaTime);
    }
}
