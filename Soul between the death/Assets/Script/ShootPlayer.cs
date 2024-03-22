using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootPlayer : MonoBehaviour
{
    public static ShootPlayer Instance;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _player;

    private float _maxAmmo = 5; public float MaxAmmo {  get { return _maxAmmo; } }
    private float _ammo = 5; public float Ammo { get { return _ammo; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GetComponent<PlayerMovement>().TouchGroundEvent.AddListener(RefillAmmo);
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started && _ammo > 0)
        {
            GameObject _bulletInstantiate = Instantiate(_bullet, new Vector3(_player.transform.position.x, transform.position.y, 0), Quaternion.identity);
            --_ammo;
        }
    }

    public void RefillAmmo()
    {
        _ammo = _maxAmmo;
    }
}
