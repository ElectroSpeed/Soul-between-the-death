using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    private bool _rightMovement = false;
    private bool _leftMovement = false;

    [SerializeField] private float _maxFallSpeed = 5;
    [SerializeField] private float _jumpForce = 5;

    private bool _isOnFloor = false; public bool IsOnFloor { get { return _isOnFloor; } }

    public UnityEvent TouchGroundEvent;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rightMovement)
        {
            RightMovement();
        }

        if (_leftMovement)
        {
            LeftMovement();
        }

        if (!_rightMovement && !_leftMovement)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }

        if (_rb.velocity.y < -_maxFallSpeed)
        {
            _rb.useGravity = false;
        } 
        else
        {
            _rb.useGravity = true;
        }
        //transform.position += new Vector3(0, -6, 0) * Time.deltaTime;

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1, ~(1 << LayerMask.NameToLayer("bullet") | 1 << LayerMask.NameToLayer("Ignore Raycast"))))
        {
            TouchGroundEvent?.Invoke();
            _isOnFloor = true;
        }
        else
        {
            _isOnFloor = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && _isOnFloor)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    public void PlayerRightCheck(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _rightMovement = true;
        }
        if (context.canceled)
        {
            _rightMovement = false;
        }
    }

    public void PlayerLeftCheck(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            _leftMovement = true;
        }
        if (context.canceled)
        {
            _leftMovement = false;
        }
    }

    private void RightMovement()
    {
        _rb.velocity = new Vector3(4, _rb.velocity.y, 0);
    }
    private void LeftMovement()
    {
        _rb.velocity = new Vector3(-4, _rb.velocity.y, 0);
    }
}
