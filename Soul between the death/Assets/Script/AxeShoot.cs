using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeShoot : MonoBehaviour
{
    private Rigidbody _rb;

    public AudioSource _audioSource;

    [SerializeField] private float _maxFallSpeed = 5;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
            _audioSource.Play();
        }
        
        
        Destroy(gameObject);
    }
}
