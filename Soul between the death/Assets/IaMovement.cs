using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaMovement : MonoBehaviour
{
    [SerializeField] private bool _right;
    [SerializeField] private bool _left;
    // Start is called before the first frame update
    void Start()
    {
        if(_left)
        {
            RightIA();
        }
        if (_right)
        {
            LeftIA();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_right)
        {
            LeftIA();
        }
        else
        {
            RightIA();
        }
    }

    private void RightIA()
    {
        if (transform.position.x >= 6)
        {
            _right = true;
            _left = false;
        }
        else
        {
            transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
        }
    }

    private void LeftIA()
    {
        if (transform.position.x <= -6)
        {
            transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
        }
        else
        {
            _right = false;
            _left = true;
        }
    }
}
