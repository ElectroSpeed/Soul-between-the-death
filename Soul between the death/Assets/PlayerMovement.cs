using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private bool _rightMovement = false;
    private bool _leftMovement = false;
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
        transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
    }
    private void LeftMovement()
    {
        transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
    }
}
