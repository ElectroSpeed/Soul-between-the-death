using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    public int _health = 3;
    [SerializeField] private GameObject _player;
    [SerializeField] private ButtonManager _menu;

    public static LifePlayer Instance;

    public AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemi")|| other.gameObject.CompareTag("MapDestroy"))
        {
            _audioSource.Play();
            _health--;
            if (_health == 0)
            {
                _menu.EndMenu();
            }
        }
    }
}
