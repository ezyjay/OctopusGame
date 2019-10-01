using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour 
{
    public Rigidbody _rb;
    public PlayerRotation _playerRotation;
    public float _deccelerationModifier;
    public float _speed;

    private Vector2 _inputDirection;
    private Vector2 _previousInputDirection = Vector2.zero;
    private float _changeDirectionDeccelerationModifier = 0.5f;

    void Update()
    {
        _inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate() {
        
        if (_inputDirection != Vector2.zero) { 

            if (_inputDirection.normalized.x != _previousInputDirection.x || _inputDirection.normalized.y != _previousInputDirection.y)
                _rb.velocity = _changeDirectionDeccelerationModifier * _rb.velocity;

            _rb.AddForce(_inputDirection.normalized * _speed);

            _playerRotation.RotateTowardsInputDirection(_inputDirection);

            _previousInputDirection = _inputDirection.normalized;
        } 
        else {

            _playerRotation.RotateBack();

            if (_rb.velocity.magnitude > 0)
                _rb.velocity = _deccelerationModifier * _rb.velocity;
        }
    }
}
