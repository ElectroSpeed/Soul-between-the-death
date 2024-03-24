using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    public int _health;
    [SerializeField] private GameObject _player;
    [SerializeField] private ButtonManager _menu;
    [SerializeField] private GameObject _damage;

    public static LifePlayer Instance;

    public AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _health = 3;
    }


    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_health);
    }

    public void UpHealth()
    {
        _health++;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemi"))
        {
            _audioSource.Play();
            _health--;
            Instantiate(_damage, _player.transform.position, Quaternion.identity);
            if (_health == 0)
            {
                _menu.EndMenu();
            }
        }
    }
}
