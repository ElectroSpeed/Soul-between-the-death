using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootPlayer : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject _bulletInstantiate = Instantiate(_bullet, new Vector3(_player.transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
