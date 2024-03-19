using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public List <GameObject> _map = new List<GameObject>();
    [SerializeField] private GameObject _player;
    public int _level = 2;

    private void OnTriggerEnter(Collider other)
    {
        int _rand = Random.Range(0, _map.Count);
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(_map[_rand], new Vector3(9, -14 * _level, 0), Quaternion.identity);
            _level += 1;
        }
    }
}
