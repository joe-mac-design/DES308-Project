using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Components")]
    private Rigidbody2D _rigidBody2D;

    [Header("Layer Masks")]
    [SerializeField] private LayerMask _groundLayer;

    [Header("Movement")]
    [SerializeField] private float _movementAcceleration;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _groundLinearDrag;
    private float _horizontalDirection;
    private bool _changingDirection => (_rigidBody2D.velocity.x > 0f && _horizontalDirection < 0f) || (_rigidBody2D.velocity.x < 0f && _horizontalDirection > 0f);

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 12;
    [SerializeField] private float _airLinearDrag = 2.5f;
    [SerializeField] private float _fallMultiplier = 8f;
    [SerializeField] private float _lowJumpFallMultiplier = 5f;
    private bool _canJump => Input.GetButtonDown("Jump") && _onGround;

    [Header("Ground Collision")]
    [SerializeField] private float _groundRaycastLength;
    [SerializeField] private Vector3 _groundRaycastOffset;
    private bool _onGround;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalDirection = GetInput().x;
        if (_canJump) Jump();
    }

    private void FixedUpdate()
    {
        CheckCollisions();
        MoveCharacter();
        if (_onGround)
        {
            ApplyGroundLinearDrag();
        }
        else
        {
            ApplyAirLinearDrag();
            FallMultiplier();
        }
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MoveCharacter()
    {
        _rigidBody2D.AddForce(new Vector2(_horizontalDirection, 0f) * _movementAcceleration);
        if(Mathf.Abs(_rigidBody2D.velocity.x) > _maxMoveSpeed)
        {
            _rigidBody2D.velocity = new Vector2(Mathf.Sign(_rigidBody2D.velocity.x) * _maxMoveSpeed, _rigidBody2D.velocity.y);
        }
    }

    private void ApplyGroundLinearDrag()
    {
        if (Mathf.Abs(_horizontalDirection) < 0.4f || _changingDirection)
        {
            _rigidBody2D.drag = _groundLinearDrag;
        }
        else
        {
            _rigidBody2D.drag = 0f;
        }
    }

    private void ApplyAirLinearDrag()
    {
        _rigidBody2D.drag = _airLinearDrag;
    }

    private void Jump()
    {
        _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, 0f);
        _rigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void FallMultiplier()
    {
        if (_rigidBody2D.velocity.y < 0)
        {
            _rigidBody2D.gravityScale = _fallMultiplier;
        }
        else if (_rigidBody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rigidBody2D.gravityScale = _lowJumpFallMultiplier;
        }
        else
        {
            _rigidBody2D.gravityScale = 1f;
        }
    }

    private void CheckCollisions()
    {
        _onGround = Physics2D.Raycast(transform.position * _groundRaycastLength, Vector2.down, _groundRaycastLength, _groundLayer);
        _onGround = Physics2D.Raycast(transform.position + _groundRaycastOffset, Vector2.down, _groundRaycastLength, _groundLayer) ||
                    Physics2D.Raycast(transform.position - _groundRaycastOffset, Vector2.down, _groundRaycastLength, _groundLayer);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundRaycastLength);
        Gizmos.DrawLine(transform.position + _groundRaycastOffset, transform.position + _groundRaycastOffset + Vector3.down * _groundRaycastLength);
        Gizmos.DrawLine(transform.position - _groundRaycastOffset, transform.position - _groundRaycastOffset + Vector3.down * _groundRaycastLength);

    }

}
