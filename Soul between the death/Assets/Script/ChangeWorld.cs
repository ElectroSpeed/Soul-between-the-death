using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour
{
    private bool _devil = true ;
    public Material _rockMaterial;
    void Start()
    {

    }

    Color HexToColor(string hex)
    {
        if (hex.StartsWith("#") && hex.Length == 7)
        {
            Color color;
            if (ColorUtility.TryParseHtmlString(hex, out color))
            {
                return color;
            }
        }
        return Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Color"))
        {
            Debug.Log("Contact");
            if (_devil)
            {
                Debug.Log("ColorChange");
                _rockMaterial.color = HexToColor("#FF0000");
                _devil = false;
            }
            else if (!_devil)
            {
                Debug.Log("ColorChange");
                _rockMaterial.color = HexToColor("#525252");
                _devil = true;
            }

        }

    }
}
