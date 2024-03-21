using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoove : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera.transform.position = new Vector3(0, _player.transform.position.y, -11);
    }

    // Update is called once per frame
    void Update()
    {
        _camera.transform.position = new Vector3(0, _player.transform.position.y, -11);
    }
}
