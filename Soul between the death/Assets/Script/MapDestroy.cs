using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDestroy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy")) 
        {
            Destroy(gameObject);
        }
    }
}
