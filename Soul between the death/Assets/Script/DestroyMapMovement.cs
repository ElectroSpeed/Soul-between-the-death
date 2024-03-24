using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMapMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _destroy;
    // Start is called before the first frame update
    void Start()
    {
        _destroy.transform.position = new Vector3(0, _player.transform.position.y + 60, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _destroy.transform.position = new Vector3(0, _player.transform.position.y + 60, 0);
    }
}
