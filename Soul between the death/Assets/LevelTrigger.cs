using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public List <GameObject> _map = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        int _rand = Random.Range(0, _map.Count);
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(_map[_rand], new Vector3(0,-11,0), Quaternion.identity);
        }
    }
}
