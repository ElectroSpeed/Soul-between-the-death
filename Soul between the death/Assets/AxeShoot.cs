using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeShoot : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float _maxFallSpeed = 5;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_rb.velocity.y < -_maxFallSpeed)
        {
            _rb.useGravity = false;
        }
        else
        {
            _rb.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            return;

        Debug.Log(other.tag);
        if (other.gameObject.CompareTag("MapDestroy") || other.gameObject.CompareTag("Ennemi"))
        {
            Destroy(other.gameObject);
        }
        
        
        Destroy(gameObject);
    }
}
